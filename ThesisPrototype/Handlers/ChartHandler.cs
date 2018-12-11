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
    /// <summary>
    /// This class handles the creation of ChartViewModels, which are then displayed on the Razor pages.
    /// </summary>
    public class ChartHandler
    {
        private readonly KpiRetriever _kpiRetriever;
        private readonly KpiValueRetriever _kpiValueRetriever;
        public ChartHandler(KpiRetriever kpiRetriever, KpiValueRetriever kpiValueRetriever)
        {
            _kpiRetriever = kpiRetriever;
            _kpiValueRetriever = kpiValueRetriever;
        }

        /// <summary>
        /// Creates a list of chartviewmodels (One chart for each EKpiType) using the KpiValues
        /// between rangeBegin and rangeEnd, for the ship with the given id.
        /// </summary>
        public List<ChartViewModel> GetKpiChartViewModels(long shipId, DateTime rangeBegin, DateTime rangeEnd)
        {
            // Only taking 4 KPIs per type so that the charts dont get too crowded 
            List<Kpi> averagesKpis = _kpiRetriever.GetKpisByType(EKpiType.Average)
                                                  .Take(4)
                                                  .ToList();

            List<Kpi> combinationsKpis = _kpiRetriever.GetKpisByType(EKpiType.Combination)
                                                      .Take(4)
                                                      .ToList();

            List<Kpi> trendingKpis = _kpiRetriever.GetKpisByType(EKpiType.Trending)
                                                  .Take(4)
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
                valuesPerKpi.Add(_kpiValueRetriever.GetRange(shipId, new List<EKpi> { kpi.KpiEnum },
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
                    data = kpiValues.Select(v => new ChartDataPointViewModel() { x = v.Date.ToUnixMilliTs(), y = v.Value })
                                .ToArray()
                });
            }
            return chartSerieViewModels.ToArray();
        }
    }
}
