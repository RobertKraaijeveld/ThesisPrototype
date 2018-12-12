using System;
using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;
using ThesisPrototype.Enums;

namespace ThesisPrototype.DataModels
{
    /// <summary>
    /// An EF entity representing a Key Performance Indicator. 
    /// </summary>
    [MessagePackObject]
    public class Kpi 
    {
        [SerializationConstructor]
        public Kpi(int KpiId, EKpi KpiEnum, EKpiType KpiType)
        {
            this.KpiId = KpiId;
            this.KpiEnum = KpiEnum;
            this.KpiType = KpiType;
        }

        public Kpi(EKpi KpiEnum, EKpiType KpiType)
        {
            this.KpiEnum = KpiEnum;
            this.KpiType = KpiType;
        }

        [Key(0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KpiId { get; set; }

        [Key(1)]
        public EKpi KpiEnum { get; set; }

        [Key(2)]
        public EKpiType KpiType { get; set; }
    }
}
