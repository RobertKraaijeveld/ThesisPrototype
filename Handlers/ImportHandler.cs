using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ThesisPrototype.DataModels;
using ThesisPrototype.Calculators;
using ThesisPrototype.Retrievers;

namespace ThesisPrototype
{
    public class ImportHandler
    {
        private readonly KpiCalculationHandler _kpiCalculationHandler;
        private readonly SensorValuesRowRetriever _sensorValuesRowRetriever;
        private readonly KpiValueRetriever _kpiValueRetriever;

        public ImportHandler(KpiCalculationHandler kpiCalculationHandler,
                             SensorValuesRowRetriever sensorValuesRowRetriever, 
                             KpiValueRetriever kpiValueRetriever)
        {
            _kpiCalculationHandler = kpiCalculationHandler;
            _sensorValuesRowRetriever = sensorValuesRowRetriever;
            _kpiValueRetriever = kpiValueRetriever;
        }


        public void Handle(IFormFile importFile)
        {
            var import = this.SaveImportAndReturnRows(importFile);
            _kpiCalculationHandler.Handle(import.SensorValues, import.ShipId, import.ImportDate);

            // TODO: TESTING
            var beginmin = import.ImportDate.AbsoluteStart();
            var beginMinuteUnixTs = import.ImportDate.AbsoluteStart().ToUnixTs();
            var endMinuteUnixTs = import.ImportDate.AbsoluteEnd().ToUnixTs();
            var valuesWeJustImported = _sensorValuesRowRetriever.GetRange(import.ShipId, beginMinuteUnixTs, endMinuteUnixTs);

            var kpiWeJustCreated = _kpiValueRetriever.GetSingle(import.ShipId, EKpi.DailyAveragesKpi1, import.ImportDate);
        }


        private DataImport SaveImportAndReturnRows(IFormFile importFile)
        {
            string importFileName = importFile.FileName;
            long shipIdOfImport = GetShipIdFromFileName(importFileName);
            DateTime dateTimeOfImport = GetImportDateFromFileName(importFileName);

            if (importFile.Length > 0)
            {
                var rows = new List<SensorValuesRow>();

                using (var stream = new StreamReader(importFile.OpenReadStream()))
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

                        Dictionary<ESensor, string> rowAsDict = this.RowToDictionary(header, currentLine);
                        rows.Add(new SensorValuesRow(shipIdOfImport, dateTimeOfImport, rowAsDict));
                    }
                }

                // Saving all rows at once to avoid having to open a DB connection for each row
                SaveSensorValues(rows.ToList());

                var dataImport = new DataImport(shipIdOfImport, dateTimeOfImport, rows);
                return dataImport;
            }
            else
            {
                throw new Exception("Empty import file.");
            }
        }

        private void SaveSensorValues(List<SensorValuesRow> rows)
        {
            RedisDatabaseApi.Create<SensorValuesRow>(rows);
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
                return ctx.Ships.Where(x => x.ImoNumber == imo).Single().ShipId;
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