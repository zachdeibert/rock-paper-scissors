using System;

namespace Com.GitHub.ZachDeibert.RockPaperScissors.Ai.NearestNeighbor {
    public class VectorValue {
        public Vector Vector;
        public double Numerator;
        public double Denominator;
        public double Value => Numerator / Denominator;
    }
}
