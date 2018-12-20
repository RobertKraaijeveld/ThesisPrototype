using System;
using System.Linq;
using System.Collections.Generic;
using ThesisPrototype.DataModels;
using ThesisPrototype.Enums;

namespace ThesisPrototype.Calculators
{
    public class KpiCalculatorFactory
    {
        /// <summary>
        /// Returns a implementation of IKpiCalculator, given a shipId and a Kpi entity.
        /// This calculator can then be used to calculate KpiValues.
        /// </summary>

        public IKpiCalculator GetCalculator(long shipId, Kpi kpi)
        {
            // Randomly determining which sensor to use for calculating the KPI's.
            // Obviously, in a 'real' application, a bit more thought is required to determine which KPI uses which sensor.
            var random = new Random();

            // Possible sensors are all sensors with the exception of the row timestamp
            var possibleSensors = Enum.GetValues(typeof(ESensor)).Cast<ESensor>()
                                                                 .Where(s => s.Equals(ESensor.ts) == false)
                                                                 .ToArray();
                                                                 
            var randomSensor = (ESensor) possibleSensors.GetValue(random.Next(possibleSensors.Length));
            var secondRandomSensor = (ESensor) possibleSensors.GetValue(random.Next(possibleSensors.Length));
            
            switch (kpi.KpiEnum)
            {
                case EKpi.DailyExpensiveKpi1:
                case EKpi.DailyExpensiveKpi2:
                case EKpi.DailyExpensiveKpi3:
                case EKpi.DailyExpensiveKpi4:
                case EKpi.DailyExpensiveKpi5:
                case EKpi.DailyExpensiveKpi6:
                case EKpi.DailyExpensiveKpi7:
                case EKpi.DailyExpensiveKpi8:
                case EKpi.DailyExpensiveKpi9:
                case EKpi.DailyExpensiveKpi10:
                    return new ExpensiveKpiCalculator(shipId, randomSensor, kpi);

                case EKpi.DailyAveragesKpi1:
                case EKpi.DailyAveragesKpi2:
                case EKpi.DailyAveragesKpi3:
                case EKpi.DailyAveragesKpi4:
                case EKpi.DailyAveragesKpi5:
                case EKpi.DailyAveragesKpi6:
                case EKpi.DailyAveragesKpi7:
                case EKpi.DailyAveragesKpi8:
                case EKpi.DailyAveragesKpi9:
                case EKpi.DailyAveragesKpi10:
                case EKpi.DailyAveragesKpi11:
                case EKpi.DailyAveragesKpi12:
                case EKpi.DailyAveragesKpi13:
                case EKpi.DailyAveragesKpi14:
                case EKpi.DailyAveragesKpi15:
                case EKpi.DailyAveragesKpi16:
                case EKpi.DailyAveragesKpi17:
                case EKpi.DailyAveragesKpi18:
                case EKpi.DailyAveragesKpi19:
                case EKpi.DailyAveragesKpi20:
                case EKpi.DailyAveragesKpi21:
                case EKpi.DailyAveragesKpi22:
                case EKpi.DailyAveragesKpi23:
                case EKpi.DailyAveragesKpi24:
                case EKpi.DailyAveragesKpi25:
                case EKpi.DailyAveragesKpi26:
                case EKpi.DailyAveragesKpi27:
                case EKpi.DailyAveragesKpi28:
                case EKpi.DailyAveragesKpi29:
                case EKpi.DailyAveragesKpi30:
                case EKpi.DailyAveragesKpi31:
                case EKpi.DailyAveragesKpi32:
                    return new AverageKpiCalculator(shipId, randomSensor, kpi);

                case EKpi.DailyCombinationKpi1:
                case EKpi.DailyCombinationKpi2:
                case EKpi.DailyCombinationKpi3:
                case EKpi.DailyCombinationKpi4:
                case EKpi.DailyCombinationKpi5:
                case EKpi.DailyCombinationKpi6:
                case EKpi.DailyCombinationKpi7:
                case EKpi.DailyCombinationKpi8:
                case EKpi.DailyCombinationKpi9:
                case EKpi.DailyCombinationKpi10:
                case EKpi.DailyCombinationKpi11:
                case EKpi.DailyCombinationKpi12:
                case EKpi.DailyCombinationKpi13:
                case EKpi.DailyCombinationKpi14:
                case EKpi.DailyCombinationKpi15:
                case EKpi.DailyCombinationKpi16:
                case EKpi.DailyCombinationKpi17:
                case EKpi.DailyCombinationKpi18:
                case EKpi.DailyCombinationKpi19:
                case EKpi.DailyCombinationKpi20:
                case EKpi.DailyCombinationKpi21:
                case EKpi.DailyCombinationKpi22:
                case EKpi.DailyCombinationKpi23:
                case EKpi.DailyCombinationKpi24:
                case EKpi.DailyCombinationKpi25:
                case EKpi.DailyCombinationKpi26:
                case EKpi.DailyCombinationKpi27:
                case EKpi.DailyCombinationKpi28:
                case EKpi.DailyCombinationKpi29:
                case EKpi.DailyCombinationKpi30:
                case EKpi.DailyCombinationKpi31:
                case EKpi.DailyCombinationKpi32:
                case EKpi.DailyCombinationKpi33:
                case EKpi.DailyCombinationKpi34:
                case EKpi.DailyCombinationKpi35:
                case EKpi.DailyCombinationKpi36:
                case EKpi.DailyCombinationKpi37:
                case EKpi.DailyCombinationKpi38:
                case EKpi.DailyCombinationKpi39:
                case EKpi.DailyCombinationKpi40:
                case EKpi.DailyCombinationKpi41:
                case EKpi.DailyCombinationKpi42:
                case EKpi.DailyCombinationKpi43:
                case EKpi.DailyCombinationKpi44:
                case EKpi.DailyCombinationKpi45:
                case EKpi.DailyCombinationKpi46:
                case EKpi.DailyCombinationKpi47:
                case EKpi.DailyCombinationKpi48:
                case EKpi.DailyCombinationKpi49:
                case EKpi.DailyCombinationKpi50:
                case EKpi.DailyCombinationKpi51:
                case EKpi.DailyCombinationKpi52:
                case EKpi.DailyCombinationKpi53:
                case EKpi.DailyCombinationKpi54:
                case EKpi.DailyCombinationKpi55:
                case EKpi.DailyCombinationKpi56:
                case EKpi.DailyCombinationKpi57:
                case EKpi.DailyCombinationKpi58:
                case EKpi.DailyCombinationKpi59:
                case EKpi.DailyCombinationKpi60:
                case EKpi.DailyCombinationKpi61:
                case EKpi.DailyCombinationKpi62:
                case EKpi.DailyCombinationKpi63:
                case EKpi.DailyCombinationKpi64:
                case EKpi.DailyCombinationKpi65:
                case EKpi.DailyCombinationKpi66:
                case EKpi.DailyCombinationKpi67:
                case EKpi.DailyCombinationKpi68:
                case EKpi.DailyCombinationKpi69:
                case EKpi.DailyCombinationKpi70:
                case EKpi.DailyCombinationKpi71:
                case EKpi.DailyCombinationKpi72:
                case EKpi.DailyCombinationKpi73:
                case EKpi.DailyCombinationKpi74:
                case EKpi.DailyCombinationKpi75:
                case EKpi.DailyCombinationKpi76:
                case EKpi.DailyCombinationKpi77:
                case EKpi.DailyCombinationKpi78:
                case EKpi.DailyCombinationKpi79:
                    return new CombinationKpiCalculator(shipId, new List<ESensor>() { randomSensor, secondRandomSensor}, kpi);

                default:
                    throw new Exception("No KpiCalculator exists for this Kpi");
            }
        }
    }
}