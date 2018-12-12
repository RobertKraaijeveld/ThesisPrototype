using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MessagePack;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
    [MessagePackObject]
    public class RedisSensorValuesRow : IRedisModel
    {
        [SerializationConstructor]
        public RedisSensorValuesRow(long shipId, long RowTimestamp,
                                    DateTime ImportTimestamp, Dictionary<ESensor, double> sensorValues)
        {
            this.RowTimestamp = RowTimestamp;
            this.ShipId = shipId;
            this.ImportTimestamp = ImportTimestamp;
            this.SensorValues = sensorValues;
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

        [Key(0)]
        public long RowTimestamp { get; set; }
        [Key(1)]
        public long ShipId { get; set; }
        [Key(2)]
        public DateTime ImportTimestamp { get; set; }
        [Key(3)]
        public Dictionary<ESensor, double> SensorValues { get; set; }


        public string ToRedisKey()
        {
            return SensorValuesRowKeyFormatter.GetKey(this.ShipId, this.RowTimestamp);
        }
    }
}