using System;
using System.Linq;
using ThesisPrototype.DatabaseApis;
using ThesisPrototype.DataModels;
using ThesisPrototype.Enums;

namespace ThesisPrototype.Seeders
{
    public static class KpiSeeder
    {
        /// <summary>
        /// Seeds the database with all KPI's.
        /// </summary>
        public static void SeedKpis()
        {
            using(var ctx = new PrototypeContext())
            {
                foreach(EKpi kpi in Enum.GetValues(typeof(EKpi)))
                {
                    if(ctx.Kpis.Any(x => x.KpiEnum.Equals(kpi)) == false)
                    {
                        ctx.Kpis.Add(new Kpi(kpi, GetKpiTypeFromEnumName(kpi)));
                    }
                }
                ctx.SaveChanges();
            }
        }

        private static EKpiType GetKpiTypeFromEnumName(EKpi kpiEnum)
        {
            if (kpiEnum.ToString().Contains("Average"))
            {
                return EKpiType.Average;
            }
            else if (kpiEnum.ToString().Contains("Combination"))
            {
                return EKpiType.Combination;
            }
            else 
            {
                return EKpiType.Trending;
            }
        }
    }
}
