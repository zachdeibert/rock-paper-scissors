using System;
using System.Collections.Generic;

namespace Com.GitHub.ZachDeibert.RockPaperScissors.Ui.Text {
    public class Container : Component {
        List<Component> children;

        public IEnumerable<Component> Children => children.AsReadOnly();

        protected override void DrawInternal() {
            foreach (Component child in Children) {
                if (child.Dirty) {
                    child.Draw();
                }
            }
        }

        public override void Invalidate() {
            foreach (Component child in Children) {
                child.Invalidate();
            }
        }

        public void Add(params Component[] components) {
            children.AddRange(components);
            foreach (Component component in components) {
                component.Parent = this;
            }
        }

        public Container() {
            children = new List<Component>();
        }
    }
}
