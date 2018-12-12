using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ThesisPrototype.DatabaseApis;
using ThesisPrototype.DataModels;
using ThesisPrototype.Enums;

namespace ThesisPrototype
{
    public abstract class AbstractImportHandler
    {
        public abstract void Handle(FileStream importFile);


        protected readonly static int SENSORVALUES_AMOUNT_PER_IMPORT = 1440;
        protected void SaveDataImportMeta(DataImportMeta dataImportMeta)
        {
            using (var context = new PrototypeContext())
            {
                context.DataImportMetas.Add(dataImportMeta);
                context.SaveChanges();
            }
        }

        protected Dictionary<ESensor, string> RowToDictionary(string header, string row)
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

        protected long GetShipIdFromFileName(string fileName)
        {
            // filename is like 1111111_20180604_030000.csv. First 7 numbers are imo
            var imo = int.Parse(fileName.Split('_')[0]);

            using (var ctx = new PrototypeContext())
            {
                return ctx.Ships.Where(x => x.ImoNumber == imo).First().ShipId;
            }
        }

        protected DateTime GetImportDateFromFileName(string fileName)
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
