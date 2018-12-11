using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ThesisPrototype.Enums;
using ThesisPrototype.RedisKeyFormatters;
using ThesisPrototype.Utilities;

namespace ThesisPrototype.DataModels
{
    /// <summary>
    /// A model for use in the Redis KV-database, 
    /// representing a single row of sensor values in a CSV import file.
    /// </summary>
    public class RedisSensorValuesRow : IRedisModel
    {
        [JsonConstructor]
        public RedisSensorValuesRow(long RowTimeStamp, long ShipId,
                                    DateTime ImportTimestamp, Dictionary<ESensor, double> SensorValues)
        {
            this.RowTimestamp = RowTimeStamp;
            this.ShipId = ShipId;
            this.ImportTimestamp = ImportTimestamp;
            this.SensorValues = SensorValues;
        }

        public RedisSensorValuesRow(long shipId, DateTime importTimeStamp, 
                                    Dictionary<ESensor, string> rowAsDictionary)
        {   
            this.ShipId = shipId;
            this.ImportTimestamp = importTimeStamp;

            // Calculating row timestamp
            var timeStampValue = DateTime.Parse(rowAsDictionary[ESensor.ts]);
            this.RowTimestamp = timeStampValue.ToUnixMilliTs();

            // Parsing all but the timestamp value to double.
            this.SensorValues = rowAsDictionary.Where(kv => !kv.Key.Equals(ESensor.ts))
                                               .ToDictionary(key => key.Key, val => double.Parse(val.Value));
        }

        public long RowTimestamp { get; set; }

        public long ShipId { get; set; }
        public DateTime ImportTimestamp { get; set; }
        public Dictionary<ESensor, double> SensorValues { get; set; }


        public string ToRedisKey()
        {
            return SensorValuesRowKeyFormatter.GetKey(this.ShipId, this.RowTimestamp);
        }
    }
}