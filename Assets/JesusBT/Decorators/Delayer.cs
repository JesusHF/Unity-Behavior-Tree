using UnityEngine;
using UnityEngine.Assertions;

namespace JHFBehaviorTree
{
    public class Delayer : Decorator
    {
        private float _waitTime = 0f; // in seconds
        private float _waitCounter = 0f;

        public Delayer(Node child, float time) : base(child)
        {
            Assert.IsNotNull(_child);
            _waitTime = time;
        }

        public override void Restart()
        {
            base.Restart();
            _waitCounter = 0f;
        }

        public override NodeStatus OnUpdate()
        {
            _waitCounter += Time.deltaTime;
            if (_waitCounter < _waitTime)
            {
                _state = NodeStatus.Running;
                return _state;
            }

            _state = _child.Evaluate();
            return _state;
        }
    }
}
