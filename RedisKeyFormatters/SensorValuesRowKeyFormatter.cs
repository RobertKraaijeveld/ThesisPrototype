namespace ThesisPrototype.RedisKeyFormatters
{
    public static class SensorValuesRowKeyFormatter
    {
        /// <summary>
        /// Formats the given shipId, and Unix timestamp (milliseconds since Jan 1. 1970) into a string, 
        /// suitable for use as a key for a RedisSensorValuesRow.
        /// </summary>
        public static string GetKey(long shipId, long minuteUnixMilliTs)
        {
            return $"sensorvaluesrow_{shipId}_{minuteUnixMilliTs}";
        }
    }
}
