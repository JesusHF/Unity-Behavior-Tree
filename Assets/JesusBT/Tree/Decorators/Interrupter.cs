using UnityEngine;
using UnityEngine.Assertions;

namespace Jesushf
{
    public class Interrupter : Decorator
    {
        private float _duration;
        private float _counter = 0f;
        private NodeStatus _stopStatus;

        public Interrupter(Node child, float duration) : base(child)
        {
            Assert.IsNotNull(_child);
            _counter = 0f;
            _duration = duration;
            _stopStatus = NodeStatus.Failure;
        }

        public Interrupter(Node child, float duration, NodeStatus status) : base(child)
        {
            Assert.IsNotNull(_child);
            _counter = 0f;
            _duration = duration;
            _stopStatus = status;
        }

        public override void Restart()
        {
            base.Restart();
            _counter = 0f;
        }

        public override NodeStatus OnUpdate()
        {
            _counter += Time.deltaTime;
            if (_counter >= _duration)
            {
                _state = _stopStatus;
                return _state;
            }

            _state = _child.OnUpdate();
            return _state;
        }
    }
}
