using System;

namespace Com.GitHub.ZachDeibert.RockPaperScissors.Ai.NearestNeighbor.PreviousMoves {
    public class NearestNeighborPreviousMovesAi : NearestNeighborAiBase {
        Vector current;

        protected override int Number => 1;

        protected override Vector Current => current;

        protected override double Initial => 0;

        protected override double ResultToValue(Game game) {
            current = new Vector {
                Components = new double[] {
                    game.Player == GameOption.Rock ? 1 : 0,
                    game.Player == GameOption.Paper ? 1 : 0,
                    game.Player == GameOption.Scissors ? 1 : 0
                }
            };
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
    }
}
