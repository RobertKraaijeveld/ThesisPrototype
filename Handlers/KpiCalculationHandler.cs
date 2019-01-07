using System;
using System.Collections.Generic;
using ThesisPrototype.Calculators;
using ThesisPrototype.DatabaseApis;
using ThesisPrototype.DataModels;

namespace ThesisPrototype.Handlers
{
    public class KpiCalculationHandler
    {
        private readonly KpiCalculatorFactory _kpiCalculatorFactory;

        public KpiCalculationHandler(KpiCalculatorFactory kpiCalculatorFactory)
        {
            _kpiCalculatorFactory = kpiCalculatorFactory;
        }

        /// <summary>
        /// Calculates the KpiValue for each Kpi and saves them to the Redis DB using the Redis API for the given
        /// RedisSensorValuesRows. Makes use of the KpiCalculatorFactory in order to get the appropriate KpiCalculator.
        /// The DateOfImport and shipId parameters are used for the creation of the Redis keys for each KpiValue.
        /// </summary>
        public void Handle(List<RedisSensorValuesRow> importedRows, long shipId, DateTime DateOfImport)
        {
            List<RedisKpiValue> KpiValuesToSave = new List<RedisKpiValue>();

            using(var ctx = new PrototypeContext())
            {
                foreach(var kpi in ctx.Kpis)
                {
                    var calculatorForKpi = _kpiCalculatorFactory.GetCalculator(shipId, kpi);

                    var calculatedKpiValue = calculatorForKpi.Calculate(importedRows, DateOfImport);
                    KpiValuesToSave.Add(calculatedKpiValue);
                }
            }

            RedisDatabaseApi.Create<RedisKpiValue>(KpiValuesToSave);
        }
    }
}