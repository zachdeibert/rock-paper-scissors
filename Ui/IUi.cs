using System;

namespace Com.GitHub.ZachDeibert.RockPaperScissors.Ui {
    public interface IUi {
        event Action<GameOption> OnPlay;

        int Score {
            set;
        }

        void GamePlayed(Game game);

        void Start();
        
        void Stop();
    }
}
