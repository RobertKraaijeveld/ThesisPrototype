using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using ThesisPrototype.DataModels;

namespace ThesisPrototype
{
    // Represents one row of an imported CSV file.
    public class SensorValuesRow 
    {
        public SensorValuesRow(long shipId, DateTime importTimeStamp, 
                               Dictionary<ESensor, string> rowAsDictionary)
        {
            this.ShipId = shipId;
            this.ImportTimestamp = importTimeStamp;

            // Calculating row timestamp
            var timeStampValue = DateTime.Parse(rowAsDictionary[ESensor.ts]);
            var asUnixTimestamp = (Int32) (timeStampValue.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            this.RowTimestamp = asUnixTimestamp;

            // Parsing all but the timestamp value to double.
            this.SensorValues = rowAsDictionary.Where(kv => !kv.Key.Equals(ESensor.ts))
                                               .ToDictionary(key => key.Key, val => double.Parse(val.Value));
        }

        public int RowTimestamp { get; set; }
        
        public long ShipId { get; set; } 
        public DateTime ImportTimestamp { get; set; }
        public Dictionary<ESensor, double> SensorValues { get; set; }
    }
}