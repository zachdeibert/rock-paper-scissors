using System;
using System.Runtime.Loader;
using System.Threading;
using Com.GitHub.ZachDeibert.RockPaperScissors.Ai;
using Com.GitHub.ZachDeibert.RockPaperScissors.Ai.Null;
using Com.GitHub.ZachDeibert.RockPaperScissors.Ui;
using Com.GitHub.ZachDeibert.RockPaperScissors.Ui.Text;

namespace Com.GitHub.ZachDeibert.RockPaperScissors {
    class Program {
        static IAi Ai;
        static IUi Ui;
        static int Score;

        static void Stop() {
            Ui.Stop();
        }

        static void Play(GameOption player) {
            Game game = new Game {
                Player = player,
                Robot = Ai.GenerateMove()
            };
            switch (game.State) {
                case GameState.PlayerWon:
                    ++Score;
                    break;
                case GameState.RobotWon:
                    --Score;
                    break;
            }
            Ui.Score = Score;
            Ui.GamePlayed(game);
        }

        static void Main(string[] args) {
            foreach (string arg in args) {
                switch (arg) {
                    case "NullAi":
                        Ai = new NullAi();
                        break;
                    case "ConsoleUi":
                        Ui = new ConsoleUi();
                        break;
                }
            }
            if (Ai == null) {
                Ai = new NullAi();
            }
            if (Ui == null) {
                Ui = new ConsoleUi();
            }
            Ui.OnPlay += Play;
            AssemblyLoadContext.Default.Unloading += a => Stop();
            Console.CancelKeyPress += (a, b) => Stop();
            Ui.Start();
            Thread.Sleep(int.MaxValue);
        }
    }
}
