using System;
using System.Collections.Generic;
using ThesisPrototype.DataModels;


namespace ThesisPrototype.Calculators
{
    /// <summary>
    /// Does some dummy calculations on SensorValuesRows and saves the result as KpiValues.
    /// These are then inserted into the KV-store and displayed in the main page graphs. 
    /// </summary>
    public interface IKpiCalculator
    {
        /// <summary> 
        /// Returns a single RedisKpiValue given a list of RedisSensorValuesRows (these rows represent a single import)
        /// and the DateTime of the import which the RedisSensorValuesRows belong to.
        /// </summary>
        RedisKpiValue Calculate(List<RedisSensorValuesRow> sensorValues, DateTime DateOfImport);
    }
}