using System;

namespace Com.GitHub.ZachDeibert.RockPaperScissors.Ui.Text {
    public class InputBox : Component {
        protected override void DrawInternal() {
            Console.Write("{0}[1000000EEnter move:{0}[1000000C{0}[34D(R = Rock, P = Paper, S = Scissors){0}[13G", ESC);
        }
    }
}
