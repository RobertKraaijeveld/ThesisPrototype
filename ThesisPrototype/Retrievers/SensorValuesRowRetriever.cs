using System;
using System.Collections.Generic;
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
        public List<RedisSensorValuesRow> GetRange(long shipId, int startMinuteUnixMilliTs, int endMinuteUnixMilliTs)
        {
            var dtBegin = DateTimeOffset.FromUnixTimeSeconds(startMinuteUnixMilliTs);
            var dtEnd = DateTimeOffset.FromUnixTimeSeconds(endMinuteUnixMilliTs);

            List<string> keys = new List<string>();

            for (var currMinute = dtBegin; currMinute < dtEnd; currMinute = currMinute.AddMinutes(1))
            {
                keys.Add(SensorValuesRowKeyFormatter.GetKey(shipId, (Int32) currMinute.ToUnixTimeSeconds()));
            }

            return RedisDatabaseApi.Search<RedisSensorValuesRow>(keys);
        }
    }
}
