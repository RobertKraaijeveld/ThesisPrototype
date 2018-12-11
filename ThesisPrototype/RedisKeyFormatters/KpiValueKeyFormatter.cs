using System;
using System.Globalization;
using ThesisPrototype.Enums;

namespace ThesisPrototype.RedisKeyFormatters
{
    public class KpiValueKeyFormatter
    {
        /// <summary>
        /// Formats the given shipId, Kpi Enum value and Date into a string, 
        /// suitable for use as a key for a RedisKpiValue.
        /// </summary>
        public static string GetKey(long shipId, EKpi kpiEnum, DateTime date)
        {
            string key = $"kpivalue_{shipId}_{kpiEnum.ToString()}_{date.ToString(CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern)}";
            return key;
        }
    }
}