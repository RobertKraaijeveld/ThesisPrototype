using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThesisPrototype.DataModels
{
    public class KpiValue
    {
        public KpiValue(long shipId, Kpi kpi, double value)
        {
            this.ShipId = shipId;
            this.Kpi = kpi;
            this.Value = value;
        }

        public long ShipId { get; set; }
        public Kpi Kpi { get; set; }
        public double Value { get; set; }
    }
}
