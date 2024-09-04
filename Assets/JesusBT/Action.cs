using System;
using UnityEngine.Assertions;

namespace JHFBehaviorTree
{
    public abstract class Action : Node { }

    public class SimpleAction : Action
    {
        private Func<NodeStatus> _action;

        public SimpleAction(Func<NodeStatus> action)
        {
            _action = action;
            Assert.IsNotNull(_action);
        }

        public override NodeStatus OnUpdate()
        {
            return _action();
        }
    }
}
