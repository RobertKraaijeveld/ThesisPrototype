using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThesisPrototype.DataModels;

namespace ThesisPrototype.Calculators
{
    public class ExpensiveKpiCalculator : IKpiCalculator
    {
        private readonly long _shipId;
        private readonly ESensor _sensorToUse;
        private readonly Kpi _kpi;

        public ExpensiveKpiCalculator(long shipId, ESensor sensorToUse, Kpi kpi)
        {
            _shipId = shipId;
            _sensorToUse = sensorToUse;
            _kpi = kpi;
        }

        public KpiValue Calculate(List<SensorValuesRow> sensorValues)
        {
            var returnList = new List<KpiValue>();

            var asVectors = sensorValues.Select(sv => new Vector2(sv.RowTimestamp, sv.SensorValues[_sensorToUse]))
                                        .ToList();

            var randomAlphaValue = new Random().Next(0, 1);

            return ComputeSesSmoothedVectors(asVectors, randomAlphaValue).Select(v => new KpiValue(_shipId, _kpi, v.Y))
                                                                         .Last();
        }

        private List<Vector2> ComputeSesSmoothedVectors(List<Vector2> originalVectors, double alpha)
        {
            List<Vector2> smoothedVectors = new List<Vector2>();

            for (int i = 0; i < originalVectors.Count; i++)
            {
                int originalVectorX = originalVectors[i].X;
                double smoothedY = alpha * originalVectors[i].Y + (1.0f - alpha) * smoothedVectors[i - 1].Y;

                smoothedVectors.Add(new Vector2(originalVectorX, smoothedY));
            }

            return smoothedVectors;
        }

        private struct Vector2
        {
            public int X;
            public double Y;

            public Vector2(int X, double Y)
            {
                this.X = X;
                this.Y = Y;
            }
        }
    }
}
