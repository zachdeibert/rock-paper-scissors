using System;
using System.Threading;

namespace Com.GitHub.ZachDeibert.RockPaperScissors.Ui.Text {
    public class ConsoleUi : Container, IUi {
        Thread Thread;
        bool Running;
        int score;
        InvalidMoveIndicator InvalidMoveIndicator;

        public int Score {
            get {
                return score;
            }
            set {
                score = value;
                OnScoreChanged?.Invoke();
            }
        }

        public event Action OnScoreChanged;

        public event Action<Game> OnGamePlayed;

        public event Action<GameOption> OnPlay;

        public void Clear() {
            Console.Write("{0}[3;J{0}[H{0}[2J", ESC);
            Invalidate();
        }

        void RenderThread() {
            Clear();
            while (Running) {
                if (Console.KeyAvailable) {
                    Console.Write("{0}[1D {0}[1D", ESC);
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key) {
                        case ConsoleKey.R:
                            OnPlay?.Invoke(GameOption.Rock);
                            break;
                        case ConsoleKey.P:
                            OnPlay?.Invoke(GameOption.Paper);
                            break;
                        case ConsoleKey.S:
                            OnPlay?.Invoke(GameOption.Scissors);
                            break;
                        case ConsoleKey.Enter:
                            Clear();
                            break;
                        default:
                            InvalidMoveIndicator.Show = true;
                            break;
                    }
                } else if (Dirty) {
                    Draw();
                } else {
                    Thread.Sleep(100);
                }
            }
        }

        public void GamePlayed(Game game) {
            OnGamePlayed?.Invoke(game);
        }

        public void Start() {
            Running = true;
            Thread = new Thread(RenderThread);
            Thread.Start();
        }

        public void Stop() {
            Running = false;
            Thread.Join();
            Console.Write("{0}[3;J{0}[H{0}[2J", ESC);
        }

        public ConsoleUi() {
            InvalidMoveIndicator = new InvalidMoveIndicator();
            OnScoreChanged += () => InvalidMoveIndicator.Show = false;
            OnPlay += _ => InvalidMoveIndicator.Show = false;
            Add(new TitleBar(this), new InputBox(), InvalidMoveIndicator, new GameHistory(this));
        }
    }
}
