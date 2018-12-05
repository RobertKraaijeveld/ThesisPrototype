using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ThesisPrototype.Enums;

namespace ThesisPrototype.DataModels
{
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
