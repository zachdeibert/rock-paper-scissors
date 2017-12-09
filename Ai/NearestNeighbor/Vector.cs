using System;
using System.Linq;

namespace Com.GitHub.ZachDeibert.RockPaperScissors.Ai.NearestNeighbor {
    public class Vector {
        public double[] Components;

        public double MagnitudeSquared {
            get {
                return Components.Select(n => n * n).Sum();
            }
        }

        public double Magnitude {
            get {
                return Math.Sqrt(MagnitudeSquared);
            }
        }

        public static Vector operator +(Vector a, Vector b) {
            if (a == null || a.Components == null) {
                throw new ArgumentNullException(nameof(a));
            }
            if (b == null || b.Components == null) {
                throw new ArgumentNullException(nameof(b));
            }
            if (a.Components.Length != b.Components.Length) {
                throw new ArgumentOutOfRangeException("Vectors do not have the same number of components");
            }
            return new Vector {
                Components = a.Components.Zip(b.Components, (c, d) => c + d).ToArray()
            };
        }

        public static Vector operator -(Vector a, Vector b) {
            if (a == null || a.Components == null) {
                throw new ArgumentNullException(nameof(a));
            }
            if (b == null || b.Components == null) {
                throw new ArgumentNullException(nameof(b));
            }
            if (a.Components.Length != b.Components.Length) {
                throw new ArgumentOutOfRangeException("Vectors do not have the same number of components");
            }
            return new Vector {
                Components = a.Components.Zip(b.Components, (c, d) => c - d).ToArray()
            };
        }
    }
}
