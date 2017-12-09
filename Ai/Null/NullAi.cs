using System;

namespace Com.GitHub.ZachDeibert.RockPaperScissors.Ai.Null {
    public class NullAi : IAi {
        Random Random;

        public GameOption GenerateMove() {
            return (GameOption) Random.Next(3);
        }

        public void Learn(Game game) {
        }

        public NullAi() {
            Random = new Random();
        }
    }
}
