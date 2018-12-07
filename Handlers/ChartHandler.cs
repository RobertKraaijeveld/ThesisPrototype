using System;
using System.Collections.Generic;
using System.Linq;
using ThesisPrototype.DataModels;
using ThesisPrototype.Enums;
using ThesisPrototype.Retrievers;
using ThesisPrototype.Utilities;
using ThesisPrototype.ViewModels;

namespace ThesisPrototype.Handlers
{
    public class ChartHandler
    {
        private readonly KpiRetriever _kpiRetriever;
        private readonly KpiValueRetriever _kpiValueRetriever;
        public ChartHandler(KpiRetriever kpiRetriever, KpiValueRetriever kpiValueRetriever)
        {
            _kpiRetriever = kpiRetriever;
            _kpiValueRetriever = kpiValueRetriever;
        }


        public List<ChartViewModel> GetDefaultKpiChartViewModels(long shipId, DateTime rangeBegin, DateTime rangeEnd)
        {
            // Only taking 5 KPIs per type so that charts dont get too crowded 
            // TODO: FIX THIS
            List<Kpi> averagesKpis = _kpiRetriever.GetKpisByType(EKpiType.Average)
                                                  .Take(5)
                                                  .ToList();

            List<Kpi> combinationsKpis = _kpiRetriever.GetKpisByType(EKpiType.Combination)
                                                      .Take(5)
                                                      .ToList();

            List<Kpi> trendingKpis = _kpiRetriever.GetKpisByType(EKpiType.Trending)
                                                  .Take(5)
                                                  .ToList();

            List<List<RedisKpiValue>> averagesKpiValuesPerKpi = GetValuesOfMultipleKpis(shipId, averagesKpis, rangeBegin, rangeEnd);
            List<List<RedisKpiValue>> combinationsKpiValuesPerKpi = GetValuesOfMultipleKpis(shipId, combinationsKpis, rangeBegin, rangeEnd);
            List<List<RedisKpiValue>> trendingKpiValuesPerKpi = GetValuesOfMultipleKpis(shipId, trendingKpis, rangeBegin, rangeEnd);

            var chartViewModels = new List<ChartViewModel>()
            {
                CreateKpiChartViewModel("avg_kpis", "Averages KPIs", averagesKpiValuesPerKpi),
                CreateKpiChartViewModel("combo_kpis", "Combination KPIs", combinationsKpiValuesPerKpi),
                CreateKpiChartViewModel("trending_kpis", "Trending KPIs", trendingKpiValuesPerKpi),
            };

            return chartViewModels;
        }

        private List<List<RedisKpiValue>> GetValuesOfMultipleKpis(long shipId, List<Kpi> kpis, DateTime rangeBegin, DateTime rangeEnd)
        {
            var valuesPerKpi = new List<List<RedisKpiValue>>();

            foreach (var kpi in kpis)
            {
                valuesPerKpi.Add(_kpiValueRetriever.GetRange(shipId, kpis.Select(x => x.KpiEnum).ToList(),
                                                             rangeBegin, rangeEnd));
            }
            return valuesPerKpi;
        }

        private ChartViewModel CreateKpiChartViewModel(string chartId, string titleText, List<List<RedisKpiValue>> kpiValuesPerKpi)
        {
            return new ChartViewModel()
            {
                Id = chartId,
                title = new ChartTitleViewModel() { text = titleText },
                series = CreateSeriesObjects(kpiValuesPerKpi)
            };
        }

        private ChartSerieViewModel[] CreateSeriesObjects(List<List<RedisKpiValue>> kpiValuesPerKpi)
        {
            var chartSerieViewModels = new List<ChartSerieViewModel>();

            foreach (var kpiValues in kpiValuesPerKpi)
            {
                chartSerieViewModels.Add(new ChartSerieViewModel()
                {
                    name = "",
                    data = kpiValues.Select(v => new ChartDataPointViewModel() { x = v.Date.ToUnixTs(), y = v.Value })
                                .ToArray()
                });
            }
            return chartSerieViewModels.ToArray();
        }
    }
}
