using System;

namespace Com.GitHub.ZachDeibert.RockPaperScissors.Ui.Text {
    public class TitleBar : Component {
        ConsoleUi Ui;

        protected override void DrawInternal() {
            Console.Write("{0}[s", ESC);
            Console.WriteLine("{0}[2K{0}[1;1HRock Paper Scissors{0}[1000000C{0}[51DDeveloped for AP Computer Science Principles in 2017", ESC);
            Console.WriteLine("{0}[2KScore: {1}{0}[1000000C{0}[14DBy Zach Deibert", ESC, Ui.Score);
            Console.WriteLine("{0}[2K", ESC);
            Console.Write("{0}[2K{0}[u", ESC);
        }

        public TitleBar(ConsoleUi ui) {
            Ui = ui;
            Ui.OnScoreChanged += Invalidate;
        }
    }
}
