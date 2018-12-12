using System;

namespace ThesisPrototype.DataModels
{
    public class EfKpiValue
    {
        public Ship Ship { get; set; }
        public long ShipId { get; set; }
        public Kpi Kpi { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}
