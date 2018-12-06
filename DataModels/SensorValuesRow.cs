using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ThesisPrototype.Enums;
using ThesisPrototype.RedisKeyFormatters;
using ThesisPrototype.Utilities;

namespace ThesisPrototype.DataModels
{
    // Represents one row of an imported CSV file.
    public class SensorValuesRow : IRedisModel
    {
        [JsonConstructor]
        public SensorValuesRow(int RowTimeStamp, long ShipId,
                               DateTime ImportTimestamp, Dictionary<ESensor, double> SensorValues)
        {
            this.RowTimestamp = RowTimeStamp;
            this.ShipId = ShipId;
            this.ImportTimestamp = ImportTimestamp;
            this.SensorValues = SensorValues;
        }

        public SensorValuesRow(long shipId, DateTime importTimeStamp, 
                               Dictionary<ESensor, string> rowAsDictionary)
        {
            this.ShipId = shipId;
            this.ImportTimestamp = importTimeStamp;

            // Calculating row timestamp
            var timeStampValue = DateTime.Parse(rowAsDictionary[ESensor.ts]);
            this.RowTimestamp = timeStampValue.ToUnixTs();

            // Parsing all but the timestamp value to double.
            this.SensorValues = rowAsDictionary.Where(kv => !kv.Key.Equals(ESensor.ts))
                                               .ToDictionary(key => key.Key, val => double.Parse(val.Value));
        }

        public int RowTimestamp { get; set; }

        public long ShipId { get; set; }
        public DateTime ImportTimestamp { get; set; }
        public Dictionary<ESensor, double> SensorValues { get; set; }


        public string ToRedisKey()
        {
            return SensorValuesRowKeyFormatter.GetKey(this.ShipId, this.RowTimestamp);
        }
    }
}