using System.Linq;
using System.Collections.Generic;
using ThesisPrototype.DatabaseApis;
using ThesisPrototype.DataModels;
using ThesisPrototype.Enums;

namespace ThesisPrototype.Retrievers
{
    public class KpiRetriever
    {
        /// <summary>
        /// Returns a list of Kpi's who have the given EKpiType.
        /// </summary>
        public List<Kpi> GetKpisByType(EKpiType kpiType)
        {
            using(var context = new PrototypeContext())
            {
                return context.Kpis.Where(x => x.KpiType.Equals(kpiType))
                                   .ToList();
            }
        }
    }
}
