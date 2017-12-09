using System;

namespace Com.GitHub.ZachDeibert.RockPaperScissors.Ui.Text {
    public class InvalidMoveIndicator : Component {
        private bool show;

        public bool Show {
            get {
                return show;
            }
            set {
                show = value;
                Invalidate();
            }
        }

        protected override void DrawInternal() {
            Console.Write("{0}[s{0}[1000000E{0}[1F{0}[2K", ESC);
            if (Show) {
                Console.Write("{0}[1000000C{0}[11DInvalid key.", ESC);
            }
            Console.Write("{0}[u", ESC);
        }
    }
}
