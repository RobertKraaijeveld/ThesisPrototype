﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThesisPrototype.DataModels;
using ThesisPrototype.RedisKeyFormatters;

namespace ThesisPrototype.Retrievers
{
    public class KpiValueRetriever
    {
        public KpiValue GetSingle(long shipId, EKpi kpiEnum, DateTime importDate)
        {
            var key = KpiValueKeyFormatter.GetKey(shipId, kpiEnum, importDate);

            return RedisDatabaseApi.Search<KpiValue>(new List<string>() { key })
                                   .Single();
        }

        public List<KpiValue> GetRange(long shipId, EKpi kpiEnum, DateTime startDate, DateTime endDate)
        {
            List<string> keys = new List<string>();

            for (var currDate = startDate; currDate < endDate; currDate = currDate.AddDays(1))
            {
                keys.Add(KpiValueKeyFormatter.GetKey(shipId, kpiEnum, currDate));
            }

            return RedisDatabaseApi.Search<KpiValue>(keys);
        }
    }
}
