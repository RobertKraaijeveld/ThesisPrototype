using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ThesisPrototype.DataModels;

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
