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