using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThesisPrototype.DataModels;
using ThesisPrototype.Enums;
using ThesisPrototype.Retrievers;
using ThesisPrototype.ViewModels;

namespace ThesisPrototype.Handlers
{
    public class GraphHandler
    {
        private readonly KpiRetriever _kpiRetriever;
        private readonly KpiValueRetriever _kpiValueRetriever; 
        public GraphHandler(KpiRetriever kpiRetriever, KpiValueRetriever kpiValueRetriever)
        {
            _kpiRetriever = kpiRetriever;
            _kpiValueRetriever = kpiValueRetriever;
        }


        public List<ChartViewModel> GetDefaultKpiChartViewModels(long shipId, DateTime rangeBegin, DateTime rangeEnd)
        {
            // Only taking 5 KPIs per type so that charts dont get too crowded 
            // TODO: FIX THIS
            List<Kpi> averagesKpis = _kpiRetriever.GetKpisByType(EKpiType.Average)
                                                  .Take(1)
                                                  .ToList();

            List<Kpi> combinationsKpis = _kpiRetriever.GetKpisByType(EKpiType.Combination)
                                                      .Take(1)
                                                      .ToList();

            List<Kpi> trendingKpis = _kpiRetriever.GetKpisByType(EKpiType.Trending)
                                                  .Take(1)
                                                  .ToList();

            List<KpiValue> averagesKpiValues = GetValuesOfMultipleKpis(shipId, averagesKpis, rangeBegin, rangeEnd);
            List<KpiValue> combinationsKpiValues = GetValuesOfMultipleKpis(shipId, combinationsKpis, rangeBegin, rangeEnd);
            List<KpiValue> trendingKpiValues = GetValuesOfMultipleKpis(shipId, trendingKpis, rangeBegin, rangeEnd);

            var chartViewModels = new List<ChartViewModel>()
            {
                CreateKpiChartViewModel("avg_kpis", "Averages KPIs", averagesKpiValues),
                CreateKpiChartViewModel("combo_kpis", "Combination KPIs", combinationsKpiValues),
                CreateKpiChartViewModel("trending_kpis", "Trending KPIs", trendingKpiValues),
            };

            return chartViewModels;
        }

        private List<KpiValue> GetValuesOfMultipleKpis(long shipId, List<Kpi> kpis, DateTime rangeBegin, DateTime rangeEnd)
        {
            return _kpiValueRetriever.GetRange(shipId, kpis.Select(x => x.KpiEnum).ToList(), 
                                               rangeBegin, rangeEnd);
        }

        private ChartViewModel CreateKpiChartViewModel(string chartId, string titleText, List<KpiValue> kpiValues)
        {
            return new ChartViewModel()
            {
                Id = chartId,
                title = new ChartTitleViewModel() {text = titleText},
                series = new[] {CreateSeriesObject(kpiValues)}
            };
        }

        private ChartSerieViewModel CreateSeriesObject(List<KpiValue> kpiValues)
        {
            return new ChartSerieViewModel()
            {
                name = "",
                data = kpiValues.Select(v => new ChartDataPointViewModel(){ x = v.Date.ToUnixTs(), y = v.Value})
                                .ToArray()
            };
        }
    }
}
