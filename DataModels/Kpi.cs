using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThesisPrototype.DataModels
{
    public class Kpi 
    {
        public Kpi(EKpi KpiEnum)
        {
            this.KpiEnum = KpiEnum;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KpiId { get; set; }
        public EKpi KpiEnum { get; set; }
    }
}
