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
        private readonly SensorValuesRowRetriever _sensorValuesRowRetriever;

        public ChartRetriever(KpiRetriever kpiRetriever, KpiValueRetriever kpiValueRetriever, SensorValuesRowRetriever sensorValuesRowRetriever)
        {
            _kpiRetriever = kpiRetriever;
            _kpiValueRetriever = kpiValueRetriever;
            _sensorValuesRowRetriever = sensorValuesRowRetriever;
        }

        /// <summary>
        /// Creates a list of chartviewmodels (One chart for each EKpiType) using the KpiValues
        /// between rangeBegin and rangeEnd, for the ship with the given id.
        /// </summary>
        public List<ChartViewModel> GetDefaultKpiChartViewModels(long shipId, DateTime rangeBegin, DateTime rangeEnd)
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
                CreateChartViewModel("avg_kpis", "Averages KPIs", CreateKpiSeriesViewModels(averagesKpiValuesPerKpi)),
                CreateChartViewModel("combo_kpis", "Combination KPIs", CreateKpiSeriesViewModels(combinationsKpiValuesPerKpi)),
                CreateChartViewModel("trending_kpis", "Trending KPIs", CreateKpiSeriesViewModels(trendingKpiValuesPerKpi)),

                // TODO: MAKE THIS TOGGLEABLE IN THE UI: NO, JUST DISPLAY ELAPSED TIME IN FRONTEND
                GetEntityFrameworkSensorValuesChart(shipId, rangeBegin, rangeEnd),
                GetRedisSensorValuesChart(shipId, rangeBegin, rangeEnd),
            };

            return chartViewModels;
        }

        public ChartViewModel GetEntityFrameworkSensorValuesChart(long shipId, DateTime rangeBegin, DateTime rangeEnd)
        {
            List<ESensor> sensors = new List<ESensor>() { ESensor.sensor1 };

            return CreateChartViewModel("ef_sensorvalues", "Sensor Values (Retrieved by EF)",
                                        CreateEntityFrameworkSensorValuesSeries(shipId, sensors, rangeBegin, rangeEnd));
        }

        public ChartViewModel GetRedisSensorValuesChart(long shipId, DateTime rangeBegin, DateTime rangeEnd)
        {
            List<ESensor> sensors = new List<ESensor>() { ESensor.sensor1 };

            return CreateChartViewModel("redis_sensorvalues", "Sensor Values (Retrieved by Redis)",
                                        CreateRedisSensorValuesSeries(shipId, sensors, rangeBegin, rangeEnd));
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


        private ChartSerieViewModel[] CreateRedisSensorValuesSeries(long shipId, List<ESensor> sensors, DateTime rangeBegin, DateTime rangeEnd)
        {
            List<RedisSensorValuesRow> sensorValuesWithinRange =
                _sensorValuesRowRetriever.GetRange(shipId, rangeBegin.ToUnixMilliTs(), rangeEnd.ToUnixMilliTs());

            ChartSerieViewModel[] series = new ChartSerieViewModel[sensors.Count];
            for (int i = 0; i < series.Length; i++)
            {
                var sensor = sensors[i];
                var sensorValuesAsChartDataPoints = sensorValuesWithinRange.Select(sv => new ChartDataPointViewModel()
                {
                    x = sv.RowTimestamp,
                    y = sv.SensorValues[sensor]
                }).ToArray();

                series[i] = new ChartSerieViewModel()
                {
                    name = sensor.ToString(),
                    data = sensorValuesAsChartDataPoints
                };
            }
            return series;
        }

        private ChartSerieViewModel[] CreateEntityFrameworkSensorValuesSeries(long shipId, List<ESensor> sensors, DateTime rangeBegin, DateTime rangeEnd)
        {
            using (var context = new PrototypeContext())
            {
                ChartSerieViewModel[] series = new ChartSerieViewModel[sensors.Count];
                for (int i = 0; i < series.Length; i++)
                {
                    var sensor = sensors[i];
                    var sensorValues = context.SensorValuesRows.Where(x => x.ShipId == shipId
                                                                        && x.ImportTimestamp >= rangeBegin
                                                                        && x.ImportTimestamp <= rangeEnd)
                                                               .ToList();

                    var sensorValuesAsChartDataPoints = sensorValues.Select(sv => new ChartDataPointViewModel()
                    {
                        x = sv.RowTimestamp,
                        y = sv.GetValue(sensor)
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
            var chartSerieViewModels = new ChartSerieViewModel[kpiValuesPerKpi.Count];

            for (int i = 0; i < kpiValuesPerKpi.Count; i++)  //(var kpiValues in kpiValuesPerKpi)
            {
                RedisKpiValue[] kpiValues = kpiValuesPerKpi[i].ToArray();

                chartSerieViewModels[i] = new ChartSerieViewModel()
                {
                    name = "",
                    data = kpiValues.Select(v => new ChartDataPointViewModel() { x = v.Date.ToUnixMilliTs(), y = v.Value })
                                .ToArray()
                };
            }
            return chartSerieViewModels;
        }
    }
}
