using System;
using UnityEngine.Assertions;

namespace JHFBehaviorTree
{
    public abstract class Condition : Node { }

    public class SimpleCondition : Condition
    {
        private Func<bool> _condition;

        public SimpleCondition(Func<bool> condition)
        {
            _condition = condition;
            Assert.IsNotNull(_condition);
        }

        public override NodeStatus OnUpdate()
        {
            bool result = _condition();
            return result ? NodeStatus.Success : NodeStatus.Failure;
        }
    }
}
