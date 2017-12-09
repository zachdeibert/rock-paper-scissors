using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.GitHub.ZachDeibert.RockPaperScissors.Ai.NearestNeighbor {
    public abstract class NearestNeighborAiBase : IAi {
        List<VectorValue> LearningSet;

        protected abstract int Number {
            get;
        }
        
        protected abstract Vector Current {
            get;
        }

        protected abstract double Initial {
            get;
        }

        protected abstract GameOption ValueToOption(double value);

        protected abstract double ResultToValue(Game game);

        public GameOption GenerateMove() {
            Vector c = Current;
            if (c == null) {
                return ValueToOption(Initial);
            } else {
                IEnumerable<double> values = LearningSet.OrderBy(v => (v.Vector - c).MagnitudeSquared).Select(v => v.Value).Take(Number);
                return ValueToOption(values.Any() ? values.Average() : Initial);
            }
        }

        public void Learn(Game game) {
            Vector c = Current;
            double value = ResultToValue(game);
            if (c != null) {
                VectorValue vector = LearningSet.FirstOrDefault(v => v.Vector.Components.SequenceEqual(c.Components));
                if (vector == null) {
                    LearningSet.Add(new VectorValue {
                        Vector = c,
                        Numerator = value,
                        Denominator = 1
                    });
                } else {
                    vector.Numerator += value;
                    ++vector.Denominator;
                }
            }
        }

        public NearestNeighborAiBase() {
            LearningSet = new List<VectorValue>();
        }
    }
}
