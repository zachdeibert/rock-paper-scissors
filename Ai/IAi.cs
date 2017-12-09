using System;

namespace Com.GitHub.ZachDeibert.RockPaperScissors.Ai {
    public interface IAi {
        GameOption GenerateMove();

        void Learn(GameOption player, GameOption robot, GameState state);
    }
}
