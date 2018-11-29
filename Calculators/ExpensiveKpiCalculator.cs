using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThesisPrototype.DataModels;

namespace ThesisPrototype.Calculators
{
    public class ExpensiveKpiCalculator : IKpiCalculator
    {
        public List<KpiValue> Calculate(List<SensorValuesRow> sensorValues)
        {
            var returnList = new List<KpiValue>();
            var random = new Random();


            // Just picking a random sensor to use for calculations here.
            // In reality, it obviously doesn't work that way.
            //var randomSensorValue = SensorValuesRow.

            //return ComputeSesSmoothedVectors()

        }

        private List<Vector2> ComputeSesSmoothedVectors(List<Vector2> originalVectors, double alpha)
        {
            List<Vector2> smoothedVectors = new List<Vector2>();

            for (int i = 0; i < originalVectors.Count; i++)
            {
                int originalVectorX;
                double smoothedY;

                originalVectorX = originalVectors[i].X;
                smoothedY = alpha * originalVectors[i].Y + (1.0f - alpha) * smoothedVectors[i - 1].Y;

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
