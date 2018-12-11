using System.ComponentModel.DataAnnotations.Schema;
using ThesisPrototype.Enums;

namespace ThesisPrototype.DataModels
{
    /// <summary>
    /// An EF entity representing a Key Performance Indicator. 
    /// </summary>
    public class Kpi 
    {
        public Kpi(EKpi KpiEnum, EKpiType KpiType)
        {
            this.KpiEnum = KpiEnum;
            this.KpiType = KpiType;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KpiId { get; set; }
        public EKpi KpiEnum { get; set; }
        public EKpiType KpiType { get; set; }
    }
}
