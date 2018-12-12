using System;
using System.Collections.Generic;
using System.Linq;
using ThesisPrototype.DatabaseApis;
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
    public class ChartRetriever
    {
        private readonly KpiRetriever _kpiRetriever;
        private readonly KpiValueRetriever _kpiValueRetriever;
        public ChartRetriever(KpiRetriever kpiRetriever, KpiValueRetriever kpiValueRetriever)
        {
            _kpiRetriever = kpiRetriever;
            _kpiValueRetriever = kpiValueRetriever;
        }

        /// <summary>
        /// Creates a list of chartviewmodels (One chart for each EKpiType) using the KpiValues
        /// between rangeBegin and rangeEnd, for the ship with the given id.
        /// </summary>
        public List<ChartViewModel> GetChartViewModels(long shipId, DateTime rangeBegin, DateTime rangeEnd)
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
            
            List<ESensor> sensors = new List<ESensor>() { ESensor.sensor1, ESensor.sensor2, ESensor.sensor3, ESensor.sensor4 };

            List<List<RedisKpiValue>> averagesKpiValuesPerKpi = GetValuesOfMultipleKpis(shipId, averagesKpis, rangeBegin, rangeEnd);
            List<List<RedisKpiValue>> combinationsKpiValuesPerKpi = GetValuesOfMultipleKpis(shipId, combinationsKpis, rangeBegin, rangeEnd);
            List<List<RedisKpiValue>> trendingKpiValuesPerKpi = GetValuesOfMultipleKpis(shipId, trendingKpis, rangeBegin, rangeEnd);

            var chartViewModels = new List<ChartViewModel>()
            {
                CreateChartViewModel("avg_kpis", "Averages KPIs", CreateKpiSeriesViewModels(averagesKpiValuesPerKpi)),
                CreateChartViewModel("combo_kpis", "Combination KPIs", CreateKpiSeriesViewModels(combinationsKpiValuesPerKpi)),
                CreateChartViewModel("trending_kpis", "Trending KPIs", CreateKpiSeriesViewModels(trendingKpiValuesPerKpi)),

                // Redis sensor values chart

                // EF sensor values chart
                CreateChartViewModel("ef_sensorvalues", "Sensor Values (Retrieved by EF)", 
                                     CreateEntityFrameworkSensorValuesSeries(shipId, sensors, rangeBegin, rangeEnd))
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

        private ChartViewModel CreateChartViewModel(string chartId, string titleText, ChartSerieViewModel[] serieViewModels)
        {
            return new ChartViewModel()
            {
                Id = chartId,
                title = new ChartTitleViewModel() { text = titleText },
                series = serieViewModels
            };
        }

        // private ChartSerieViewModel[] CreateRedisSensorValuesSeries(long shipId, List<ESensor> sensors, DateTime rangeBegin, DateTime rangeEnd)
        // {

        // }

        private ChartSerieViewModel[] CreateEntityFrameworkSensorValuesSeries(long shipId, List<ESensor> sensors, DateTime rangeBegin, DateTime rangeEnd)
        {
            using(var context = new PrototypeContext())
            {
                ChartSerieViewModel[] series = new ChartSerieViewModel[sensors.Count];            
                for(int i = 0; i < series.Length; i++)
                {
                    var sensor = sensors[i];
                    var sensorValues = context.SensorValuesRows.Where(x => x.ShipId == shipId 
                                                                        && x.ImportTimestamp >= rangeBegin 
                                                                        && x.ImportTimestamp <= rangeEnd)
                                                               .ToList(); 

                    var sensorValuesAsChartDataPoints = sensorValues.Select(sv => new ChartDataPointViewModel(){
                        x = sv.RowTimestamp, y = sv.GetValue(sensor)
                    });

                    var serieForThisSensor = new ChartSerieViewModel() { name = sensor.ToString(), data = sensorValuesAsChartDataPoints.ToArray() };
                    series[i] = serieForThisSensor;
                }

                return series;
            }
        }

        private ChartSerieViewModel[] CreateKpiSeriesViewModels(List<List<RedisKpiValue>> kpiValuesPerKpi)
        {
            return CreateSeriesObjects(kpiValuesPerKpi);
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
