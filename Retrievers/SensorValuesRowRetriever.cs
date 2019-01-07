using System;
using System.Collections.Generic;
using System.Linq;
using ThesisPrototype.DatabaseApis;
using ThesisPrototype.DataModels;
using ThesisPrototype.RedisKeyFormatters;

namespace ThesisPrototype.Retrievers
{
    public class SensorValuesRowRetriever
    {
        /// <summary>
        /// Returns the RedisSensorValuesRows for the ship with the given ShipId,
        /// and whose timestamps are between the given Unix timestamps (in milliseconds since Jan 1, 1970).
        /// </summary>
        public List<RedisSensorValuesRow> GetRange(long shipId, long startMinuteUnixMilliTs, long endMinuteUnixMilliTs)
        {
            List<string> keys = new List<string>();

            for (long currMinuteInUnixMillis = startMinuteUnixMilliTs;
                 currMinuteInUnixMillis < endMinuteUnixMilliTs;
                 currMinuteInUnixMillis += 60000)
            {
                keys.Add(SensorValuesRowKeyFormatter.GetKey(shipId, currMinuteInUnixMillis)); 
            }

            return RedisDatabaseApi.Search<RedisSensorValuesRow>(keys);
        }
    }
}