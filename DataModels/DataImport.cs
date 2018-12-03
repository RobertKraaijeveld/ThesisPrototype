using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThesisPrototype.DataModels
{
    /// <summary>
    /// A DTO that represents a data import for one day.
    /// Note that this DTO does not get saved to Redis; only the individual sensor rows get saved.
    /// </summary>
    public class DataImport
    {
        private readonly static int SENSORVALUES_AMOUNT_PER_IMPORT = 1440;

        public long ShipId;
        public DateTime ImportDate;
        public List<SensorValuesRow> SensorValues;


        public DataImport(long shipId, DateTime importDate, List<SensorValuesRow> sensorValues)
        {
            if (sensorValues.Count != SENSORVALUES_AMOUNT_PER_IMPORT)
            {
                throw new Exception($"Import has to have {SENSORVALUES_AMOUNT_PER_IMPORT} rows!");
            }

            this.ShipId = shipId;
            this.ImportDate = importDate;
            this.SensorValues = sensorValues;
        }
    }
}
