using System;

namespace Com.GitHub.ZachDeibert.RockPaperScissors {
    public class Game {
        public GameOption Player;
        public GameOption Robot;
        public GameState State {
            get {
                // This is some magic based on the enumeration values
                return (GameState) (((Robot - Player) + 3) % 3);
            }
        }
    }
}
