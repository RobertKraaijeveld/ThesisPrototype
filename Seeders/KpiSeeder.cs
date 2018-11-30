using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ThesisPrototype.DataModels;

namespace ThesisPrototype.Seeders
{
    public class KpiSeeder
    {
        /// <summary>
        /// Seeds the database and the ASP.NET identity system with all KPI's.
        /// </summary>
        public static void SeedKpis()
        {
            using(var ctx = new PrototypeContext())
            {
                int counter = 1;
                foreach(EKpi kpi in Enum.GetValues(typeof(EKpi)))
                {
                    if(ctx.Kpis.Any(x => x.KpiId == counter) == false)
                    {
                        ctx.Kpis.Add(new Kpi(kpi));
                    }
                    counter++;
                }
                ctx.SaveChanges();
            }
        }
    }
}
