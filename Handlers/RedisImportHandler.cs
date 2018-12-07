using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ThesisPrototype.DatabaseApis;
using ThesisPrototype.DataModels;
using ThesisPrototype.Enums;
using ThesisPrototype.Retrievers;

namespace ThesisPrototype.Handlers
{
    public class RedisImportHandler
    {
        private readonly static int SENSORVALUES_AMOUNT_PER_IMPORT = 1440;
        private readonly KpiCalculationHandler _kpiCalculationHandler;

        public RedisImportHandler(KpiCalculationHandler kpiCalculationHandler)
        {
            _kpiCalculationHandler = kpiCalculationHandler;
        }


        public void Handle(FileStream importFile)
        {
            Tuple<DataImportMeta, List<RedisSensorValuesRow>> importMetaAndRows = this.SaveImport(importFile);
            DataImportMeta importMeta = importMetaAndRows.Item1;
            List<RedisSensorValuesRow> importRows = importMetaAndRows.Item2;

            _kpiCalculationHandler.Handle(importRows, importMeta.ShipId, importMeta.ImportDate);
        }

        private Tuple<DataImportMeta, List<RedisSensorValuesRow>> SaveImport(FileStream importFile)
        {
            string importFileName = importFile.Name.Split('\\').Last();
            long shipIdOfImport = GetShipIdFromFileName(importFileName);
            DateTime dateTimeOfImport = GetImportDateFromFileName(importFileName);

            if (importFile.Length > 0)
            {
                var rows = new List<RedisSensorValuesRow>();

                using (var stream = new StreamReader(importFile))
                {
                    string header = null;
                    string currentLine;

                    while (stream.Peek() >= 0)
                    {
                        currentLine = stream.ReadLine();

                        if (header == null)
                        {
                            header = currentLine;
                            continue; // Skipping header
                        }

                        // Throwing exception when > SENSORVALUES_AMOUNT_PER_IMPORT are found
                        if(rows.Count < SENSORVALUES_AMOUNT_PER_IMPORT)
                        {
                            Dictionary<ESensor, string> rowAsDict = this.RowToDictionary(header, currentLine);
                            rows.Add(new RedisSensorValuesRow(shipIdOfImport, dateTimeOfImport, rowAsDict));
                        }
                        else
                        {
                            throw new Exception($"Import cannot have more than {SENSORVALUES_AMOUNT_PER_IMPORT} rows!");
                        }
                    }
                }

                SaveSensorValues(rows);

                var dataImportMeta = new DataImportMeta(shipIdOfImport, dateTimeOfImport);
                SaveDataImportMeta(dataImportMeta);

                return new Tuple<DataImportMeta, List<RedisSensorValuesRow>>(dataImportMeta, rows);
            }
            else
            {
                throw new Exception("Empty import file.");
            }
        }

        private void SaveSensorValues(List<RedisSensorValuesRow> rows)
        {
            RedisDatabaseApi.Create<RedisSensorValuesRow>(rows);
        }

        private void SaveDataImportMeta(DataImportMeta dataImportMeta)
        {
            using(var context = new PrototypeContext())
            {
                context.DataImportMetas.Add(dataImportMeta);
                context.SaveChanges();
            }
        }

        private Dictionary<ESensor, string> RowToDictionary(string header, string row)
        {
            var headerAsArray = header.Split(',');
            var rowAsArray = row.Split(',');

            var returnDictionary = new Dictionary<ESensor, string>();
            for (int i = 0; i < headerAsArray.Length; i++)
            {
                var sensorNameAsEnum = (ESensor)Enum.Parse(typeof(ESensor), headerAsArray[i]);
                returnDictionary.Add(sensorNameAsEnum, rowAsArray[i]);
            }

            return returnDictionary;
        }

        private long GetShipIdFromFileName(string fileName)
        {
            // filename is like 1111111_20180604_030000.csv. First 7 numbers are imo
            var imo = int.Parse(fileName.Split('_')[0]);

            using(var ctx = new PrototypeContext())
            {
                return ctx.Ships.Where(x => x.ImoNumber == imo).First().ShipId;
            }
        }

        private DateTime GetImportDateFromFileName(string fileName)
        {
            // filename is like 1111111_20180604_030000.csv. Second set of numbers is import datetime
            var dateTimeNrs = fileName.Split('_')[1];
            var yearStr = new string(dateTimeNrs.Take(4).ToArray());
            var monthStr = new string(dateTimeNrs.Skip(4).Take(2).ToArray());
            var dayStr = new string(dateTimeNrs.Skip(6).Take(2).ToArray());

            return new DateTime(int.Parse(yearStr), int.Parse(monthStr), int.Parse(dayStr));
        }
    }
}