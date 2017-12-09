using System;
using System.Runtime.Loader;
using System.Threading;
using Com.GitHub.ZachDeibert.RockPaperScissors.Ai;
using Com.GitHub.ZachDeibert.RockPaperScissors.Ai.Null;
using Com.GitHub.ZachDeibert.RockPaperScissors.Ui;
using Com.GitHub.ZachDeibert.RockPaperScissors.Ui.Text;

namespace Com.GitHub.ZachDeibert.RockPaperScissors {
    class Program {
        static IAi Ai = new NullAi();
        static IUi Ui = new ConsoleUi();
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
            Ui.OnPlay += Play;
            AssemblyLoadContext.Default.Unloading += a => Stop();
            Console.CancelKeyPress += (a, b) => Stop();
            Ui.Start();
            Thread.Sleep(int.MaxValue);
        }
    }
}
