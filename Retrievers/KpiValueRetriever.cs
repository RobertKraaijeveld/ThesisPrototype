using System;
using System.Collections.Generic;
using ThesisPrototype.DatabaseApis;
using ThesisPrototype.DataModels;
using ThesisPrototype.Enums;
using ThesisPrototype.RedisKeyFormatters;

namespace ThesisPrototype.Retrievers
{
    public class KpiValueRetriever
    {
        public List<KpiValue> Get(long shipId, EKpi kpiEnum, DateTime importDate)
        {
            var key = KpiValueKeyFormatter.GetKey(shipId, kpiEnum, importDate);

            return RedisDatabaseApi.Search<KpiValue>(new List<string>() {key});
        }

        public List<KpiValue> GetRange(long shipId, List<EKpi> kpiEnums, DateTime startDate, DateTime endDate)
        {
            List<string> keys = new List<string>();

            for (var currDate = startDate; currDate < endDate; currDate = currDate.AddDays(1))
            {
                foreach (var kpi in kpiEnums)
                {
                    keys.Add(KpiValueKeyFormatter.GetKey(shipId, kpi, currDate));
                }
            }

            return RedisDatabaseApi.Search<KpiValue>(keys);
        }
    }
}
