using System;
using System.Collections.Generic;
using ThesisPrototype.DataModels;


namespace ThesisPrototype.Calculators
{
    /// <summary>
    /// Does some *cough* usefull *cough* calculations on SensorValuesRows and saves the result as KpiValues.
    /// These are then inserted into the KV-store and displayed in the main page graphs. 
    /// </summary>
    public interface IKpiCalculator
    {
        KpiValue Calculate(List<SensorValuesRow> sensorValues, DateTime DateOfImport);
    }
}