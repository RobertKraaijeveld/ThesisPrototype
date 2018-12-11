using System;
using System.Collections.Generic;
using System.Linq;
using ThesisPrototype.DataModels;
using ThesisPrototype.Enums;

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

        public RedisKpiValue Calculate(List<RedisSensorValuesRow> sensorValues, DateTime DateOfImport)
        {
            var returnList = new List<RedisKpiValue>();

            var asVectors = sensorValues.Select(sv => new Vector2(sv.RowTimestamp, sv.SensorValues[_sensorToUse]))
                                        .ToList();

            var randomAlphaValue = new Random().Next(0, 1);

            return ComputeSesSmoothedVectors(asVectors, randomAlphaValue).Select(v => new RedisKpiValue(_shipId, _kpi, v.Y, DateOfImport))
                                                                         .Last();
        }

        private List<Vector2> ComputeSesSmoothedVectors(List<Vector2> originalVectors, double alpha)
        {
            List<Vector2> smoothedVectors = new List<Vector2>(originalVectors.Count);
            originalVectors.ForEach(v => smoothedVectors.Add(new Vector2(v)));

            for (int i = 0; i < originalVectors.Count; i++)
            {
                long originalVectorX = originalVectors[i].X;

                double smoothedY;
                if (i > 0) smoothedY = alpha * originalVectors[i].Y + (1.0f - alpha) * smoothedVectors[i - 1].Y;
                else smoothedY = originalVectors[i].Y;

                smoothedVectors[i] = new Vector2(originalVectorX, smoothedY);
            }
            return smoothedVectors;
        }

        private struct Vector2
        {
            public long X;
            public double Y;

            public Vector2(long X, double Y)
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
