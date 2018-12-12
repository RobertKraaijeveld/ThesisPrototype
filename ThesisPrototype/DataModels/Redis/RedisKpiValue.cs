using System;
using MessagePack;
using ThesisPrototype.RedisKeyFormatters;

namespace ThesisPrototype.DataModels
{
    /// <summary>
    /// A model for use in the Redis KV-database, 
    /// representing a single KpiValue for a given day / ship combination.
    /// </summary>
    [MessagePackObject]
    public class RedisKpiValue : IRedisModel
    {
        public RedisKpiValue(long shipId, Kpi kpi, double value, DateTime date)
        {
            this.ShipId = shipId;
            this.Kpi = kpi;
            this.Value = value;
            this.Date = date;
        }

        [Key(0)]
        public long ShipId { get; set; }
        [Key(1)]
        public Kpi Kpi { get; set; }
        [Key(2)]
        public double Value { get; set; }
        [Key(3)]
        public DateTime Date { get; set; }

        public string ToRedisKey()
        {
            return KpiValueKeyFormatter.GetKey(ShipId, Kpi.KpiEnum, Date);
        }
    }
}
