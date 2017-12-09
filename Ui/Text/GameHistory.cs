using System;
using System.Collections.Generic;

namespace Com.GitHub.ZachDeibert.RockPaperScissors.Ui.Text {
    public class GameHistory : Component {
        ConsoleUi Ui;
        Game LastGame;
        int GamesPlayed;

        void GamePlayed(Game game) {
            LastGame = game;
            ++GamesPlayed;
            Invalidate();
        }

        protected override void DrawInternal() {
            if (LastGame != null) {
                Console.Write("{0}[1A{0}[s{0}[S{0}[1000000E{0}[3F", ESC);
                int playerColor;
                int robotColor;
                switch (LastGame.State) {
                    case GameState.PlayerWon:
                        playerColor = 2;
                        robotColor = 1;
                        break;
                    case GameState.RobotWon:
                        playerColor = 1;
                        robotColor = 2;
                        break;
                    default:
                        playerColor = 3;
                        robotColor = 3;
                        break;
                }
                int backColor = 232 + (GamesPlayed % 4) * 4;
                Console.Write("{0}[48;5;{5}m{0}[2K{0}[3{3}m{1}{0}[0m{0}[48;5;{5}m{0}[1000000C{0}[7D{0}[3{4}m{2}{0}[0m", ESC, LastGame.Player, LastGame.Robot, playerColor, robotColor, backColor);
                Console.Write("{0}[u", ESC);
                Ui.Invalidate();
                LastGame = null;
            } else if (GamesPlayed > 0) {
                int playerColor;
                int robotColor;
                if (Ui.Score > 0) {
                    playerColor = 2;
                    robotColor = 1;
                } else if (Ui.Score < 0) {
                    playerColor = 1;
                    robotColor = 2;
                } else {
                    playerColor = 3;
                    robotColor = 3;
                }
                Console.Write("{0}[s{0}[5;1H{0}[2K{0}[3{1}mYou{0}[0m:{0}[1000000C{0}[7D{0}[3{2}mMe{0}[0m:", ESC, playerColor, robotColor);
                Console.Write("{0}[u", ESC);
            }
        }

        public GameHistory(ConsoleUi ui) {
            Ui = ui;
            Ui.OnGamePlayed += GamePlayed;
            GamesPlayed = 0;
        }
    }
}
