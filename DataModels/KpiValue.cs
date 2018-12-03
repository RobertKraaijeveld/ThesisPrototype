using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ThesisPrototype.RedisKeyFormatters;

namespace ThesisPrototype.DataModels
{
    public class KpiValue : IRedisModel
    {
        public KpiValue(long shipId, Kpi kpi, double value, DateTime date)
        {
            this.ShipId = shipId;
            this.Kpi = kpi;
            this.Value = value;
            this.Date = date;
        }

        public long ShipId { get; set; }
        public Kpi Kpi { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }

        public string ToRedisKey()
        {
            return KpiValueKeyFormatter.GetKey(ShipId, Kpi.KpiEnum, Date);
        }
    }
}
