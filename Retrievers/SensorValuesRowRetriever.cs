using System;
using System.Collections.Generic;
using ThesisPrototype.DatabaseApis;
using ThesisPrototype.DataModels;
using ThesisPrototype.RedisKeyFormatters;

namespace ThesisPrototype.Retrievers
{
    public class SensorValuesRowRetriever
    {
        public List<SensorValuesRow> Get(long shipId, int minuteUnixTs)
        {
            var key = SensorValuesRowKeyFormatter.GetKey(shipId, minuteUnixTs);

            return RedisDatabaseApi.Search<SensorValuesRow>(new List<string>() {key});
        }

        public List<SensorValuesRow> GetRange(long shipId, int startMinuteUnixTs, int endMinuteUnixTs)
        {
            var dtBegin = DateTimeOffset.FromUnixTimeSeconds(startMinuteUnixTs);
            var dtEnd = DateTimeOffset.FromUnixTimeSeconds(endMinuteUnixTs);

            List<string> keys = new List<string>();

            for (var currMinute = dtBegin; currMinute < dtEnd; currMinute = currMinute.AddMinutes(1))
            {
                keys.Add(SensorValuesRowKeyFormatter.GetKey(shipId, (Int32) currMinute.ToUnixTimeSeconds()));
            }

            return RedisDatabaseApi.Search<SensorValuesRow>(keys);
        }
    }
}
