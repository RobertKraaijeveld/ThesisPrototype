using System.Collections.Generic;
using System.Linq;
using ThesisPrototype.DataModels;

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

        public KpiValue Calculate(List<SensorValuesRow> sensorValues)
        {
            var averageValueOfSensor = sensorValues.Select(sv => sv.SensorValues[_sensorToUse])
                                                   .Average();

            return new KpiValue(_shipId, _kpi, averageValueOfSensor);
        }
    }
}