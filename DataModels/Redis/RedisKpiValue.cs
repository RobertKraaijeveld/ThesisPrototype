using System;
using ThesisPrototype.RedisKeyFormatters;

namespace ThesisPrototype.DataModels
{
    /// <summary>
    /// A model for use in the Redis KV-database, 
    /// representing a single KpiValue for a given day / ship combination.
    /// </summary>
    public class RedisKpiValue : IRedisModel
    {
        public RedisKpiValue(long shipId, Kpi kpi, double value, DateTime date)
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
