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

        public KpiValue Calculate(List<SensorValuesRow> sensorValues, DateTime DateOfImport)
        {
            var returnList = new List<KpiValue>();

            var asVectors = sensorValues.Select(sv => new Vector2(sv.RowTimestamp, sv.SensorValues[_sensorToUse]))
                                        .ToList();

            var randomAlphaValue = new Random().Next(0, 1);

            return ComputeSesSmoothedVectors(asVectors, randomAlphaValue).Select(v => new KpiValue(_shipId, _kpi, v.Y, DateOfImport))
                                                                         .Last();
        }

        private List<Vector2> ComputeSesSmoothedVectors(List<Vector2> originalVectors, double alpha)
        {
            List<Vector2> smoothedVectors = new List<Vector2>(originalVectors.Count);
            originalVectors.ForEach(v => smoothedVectors.Add(new Vector2(v)));
            Console.WriteLine("Originalvectors count = " + originalVectors.Count);
            Console.WriteLine("SmoothedVectors count = " + smoothedVectors.Count);

            for (int i = 0; i < originalVectors.Count; i++)
            {
                int originalVectorX = originalVectors[i].X;

                double smoothedY;
                if (i > 0) smoothedY = alpha * originalVectors[i].Y + (1.0f - alpha) * smoothedVectors[i - 1].Y;
                else smoothedY = originalVectors[i].Y;

                smoothedVectors[i] = new Vector2(originalVectorX, smoothedY);
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

            public Vector2(Vector2 v)
            {
                this.X = v.X;
                this.Y = v.Y;
            }
        }
    }
}
