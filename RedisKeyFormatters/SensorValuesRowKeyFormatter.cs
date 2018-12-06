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
