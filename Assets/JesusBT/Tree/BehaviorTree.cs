namespace Jesushf
{
    public class BehaviorTree
    {
        private Node _root = null;
        private NodeStatus _state = NodeStatus.Running;

        public BehaviorTree(Node root)
        {
            _root = root;
        }

        public void UpdateTree()
        {
            if (_state != NodeStatus.Running)
            {
                _state = NodeStatus.Running;
                _root.Restart();
            }

            _state = _root.OnUpdate();
        }
    }
}
