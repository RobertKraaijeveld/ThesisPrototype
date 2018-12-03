using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThesisPrototype.RedisKeyFormatters
{
    public static class SensorValuesRowKeyFormatter
    {
        public static string GetKey(long shipId, int minuteUnixTs)
        {
            return $"sensorvaluesrow_{shipId}_{minuteUnixTs}";
        }
    }
}
