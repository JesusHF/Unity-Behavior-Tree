using System;
using UnityEngine.Assertions;

namespace JHFBehaviorTree
{
    public abstract class Action : Node { }

    public class SimpleAction : Action
    {
        private Func<NodeStatus> _action = null;
        private System.Action _voidAction = null;

        public SimpleAction(Func<NodeStatus> action)
        {
            _action = action;
            Assert.IsNotNull(_action);
        }

        public SimpleAction(System.Action action)
        {
            _voidAction = action;
            Assert.IsNotNull(_voidAction);
        }

        public override NodeStatus OnUpdate()
        {
            if (_action != null)
            {
                return _action();
            }
            
            _voidAction?.Invoke();
            return NodeStatus.Success;
        }
    }
}
