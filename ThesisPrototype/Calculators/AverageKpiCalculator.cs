using System;
using System.Collections.Generic;
using System.Linq;
using ThesisPrototype.DataModels;
using ThesisPrototype.Enums;

namespace ThesisPrototype.Calculators
{
    public class AverageKpiCalculator : IKpiCalculator
    {
        private readonly long _shipId; 
        private readonly ESensor _sensorToUse;
        private readonly Kpi _kpi;

        public AverageKpiCalculator(long shipId, ESensor sensorToUse, Kpi kpi)
        {
            _shipId = shipId;
            _sensorToUse = sensorToUse;
            _kpi = kpi;
        }

        public RedisKpiValue Calculate(List<RedisSensorValuesRow> sensorValues, DateTime DateOfImport)
        {
            var averageValueOfSensor = sensorValues.Select(sv => sv.SensorValues[_sensorToUse])
                                                   .Average();

            return new RedisKpiValue(_shipId, _kpi, averageValueOfSensor, DateOfImport);
        }
    }
}