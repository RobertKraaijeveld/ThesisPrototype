using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ThesisPrototype.DatabaseApis;
using ThesisPrototype.DataModels;
using ThesisPrototype.Enums;
using ThesisPrototype.RedisKeyFormatters;

namespace ThesisPrototype.Retrievers
{
    public class KpiValueRetriever
    {
        /// <summary>
        /// Returns the RedisKpiValues for the given KpiEnums which have the given ShipId,
        /// and whose timestamps are between the given startDate and endDate.
        /// </summary>
        public List<RedisKpiValue> GetRange(long shipId, List<EKpi> kpiEnums, DateTime startDate, DateTime endDate)
        {
            List<string> keys = new List<string>();

            for (var currDate = startDate; currDate < endDate; currDate = currDate.AddDays(1))
            {
                foreach (var kpi in kpiEnums)
                {
                    keys.Add(KpiValueKeyFormatter.GetKey(shipId, kpi, currDate));
                }
            }

            return RedisDatabaseApi.Search<RedisKpiValue>(keys);
        }
    }
}
