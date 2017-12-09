using System;

namespace Com.GitHub.ZachDeibert.RockPaperScissors.Ui.Text {
    public class Component {
        protected const char ESC = (char) 27;

        public Component Parent {
            get;
            set;
        }

        public bool Dirty {
            get;
            private set;
        }

        void InvalidateInternal() {
            Dirty = true;
            if (Parent != null) {
                Parent.InvalidateInternal();
            }
        }

        public virtual void Invalidate() {
            InvalidateInternal();
        }

        protected virtual void DrawInternal() {
        }

        public void Draw() {
            Dirty = false;
            DrawInternal();
        }
    }
}
