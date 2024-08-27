namespace Jesushf
{
    public class Decorator : Node
    {
        protected Node _child = null;

        public Decorator(Node child) : base()
        {
            child.SetParent(this);
            _child = child;
        }

        public override void Restart()
        {
            base.Restart();
            _child.Restart();
        }
    }
}
