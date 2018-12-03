using System;
using System.Collections.Generic;
using System.Linq;
using ThesisPrototype.DataModels;

namespace ThesisPrototype.Calculators
{
    public class CombinationKpiCalculator : IKpiCalculator
    {
        private readonly long _shipId;
        private readonly List<ESensor> _sensorsToUse;
        private readonly Kpi _kpi;

        public CombinationKpiCalculator(long shipId, List<ESensor> sensorsToUse, Kpi kpi)
        {
            _shipId = shipId;
            _sensorsToUse = sensorsToUse;
            _kpi = kpi;
        }

        public KpiValue Calculate(List<SensorValuesRow> sensorValues, DateTime DateOfImport)
        {
            var multipliedSensorValues = sensorValues.Select(sv => {
                double res = 0;

                foreach(var sensor in _sensorsToUse)
                {
                    res *= sv.SensorValues[sensor];
                }
            
                return res;
            }).ToList();

            var sum = multipliedSensorValues.Sum();
            return new KpiValue(_shipId, _kpi, sum, DateOfImport);
        }
    }
}