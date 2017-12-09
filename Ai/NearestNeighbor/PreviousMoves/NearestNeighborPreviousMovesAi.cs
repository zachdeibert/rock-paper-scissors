using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.GitHub.ZachDeibert.RockPaperScissors.Ai.NearestNeighbor.PreviousMoves {
    public class NearestNeighborPreviousMovesAi : NearestNeighborAiBase {
        const int PreviousMovesToConsider = 10;
        IEnumerable<double> Knowledge;

        protected override int Number => 10;

        protected override Vector Current => Knowledge.Count() >= 3 * PreviousMovesToConsider ? new Vector {
            Components = Knowledge.ToArray()
        } : null;

        protected override double Initial => 0;

        protected override double ResultToValue(Game game) {
            Knowledge = new double[] {
                game.Player == GameOption.Rock ? 1 : 0,
                game.Player == GameOption.Paper ? 1 : 0,
                game.Player == GameOption.Scissors ? 1 : 0
            }.Concat(Knowledge).Take(3 * PreviousMovesToConsider);
            return (((int) game.Player) + 1) % 3;
        }

        protected override GameOption ValueToOption(double value) {
            while (value < -0.5) {
                value += 3;
            }
            while (value >= 2.5) {
                value -= 3;
            }
            return (GameOption) Math.Round(value);
        }

        public NearestNeighborPreviousMovesAi() {
            Knowledge = new double[0];
        }
    }
}
