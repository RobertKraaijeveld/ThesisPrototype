using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThesisPrototype.DataModels;
using ThesisPrototype.ViewModels;

namespace ThesisPrototype.Handlers
{
    public class GraphHandler
    {
        public ChartViewModel CreateKpiChartViewModel(string titleText, List<KpiValue> kpiValues)
        {
            return new ChartViewModel()
            {
                title = new ChartTitleViewModel() {text = titleText},
                series = new[] {CreateSeriesObject(kpiValues)}
            };
        }

        // Only one series at once supported for now.
        private ChartSerieViewModel CreateSeriesObject(List<KpiValue> kpiValues)
        {
            return new ChartSerieViewModel()
            {
                name = "",
                data = kpiValues.Select(v => new ChartDataPointViewModel(){ x = v.Value, y = v.Date.ToUnixTs()})
                                .ToArray()
            };
        }
    }
}
