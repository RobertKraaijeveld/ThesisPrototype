using System;
using System.Collections.Generic;
using System.Linq;
using ThesisPrototype.DataModels;
using ThesisPrototype.Enums;

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

        public RedisKpiValue Calculate(List<RedisSensorValuesRow> sensorValues, DateTime DateOfImport)
        {
            var multipliedSensorValues = sensorValues.Select(sv => {
                double res = 1;

                foreach(var sensor in _sensorsToUse)
                {
                    res = (res * sv.SensorValues[sensor]);
                }
            
                return res;
            }).ToList();

            var sum = multipliedSensorValues.Sum();
            return new RedisKpiValue(_shipId, _kpi, sum, DateOfImport);
        }
    }
}