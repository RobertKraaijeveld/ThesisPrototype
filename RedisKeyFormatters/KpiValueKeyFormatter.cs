using System;
using System.Globalization;
using ThesisPrototype.Enums;

namespace ThesisPrototype.RedisKeyFormatters
{
    public class KpiValueKeyFormatter
    {
        public static string GetKey(long shipId, EKpi kpiEnum, DateTime date)
        {
            return $"kpivalue_{shipId}_{kpiEnum.ToString()}_{date.ToString(CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern)}";
        }
    }
}
