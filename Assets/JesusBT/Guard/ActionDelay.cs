using UnityEngine;

namespace Jesushf
{
    public class ActionDelay : Action
    {
        private float _waitTime = 0f; // in seconds
        private float _waitCounter = 0f;

        public ActionDelay(float waitTime)
        {
            _waitTime = waitTime;
        }

        public override NodeStatus OnUpdate()
        {
            _waitCounter += Time.deltaTime;
            if (_waitCounter >= _waitTime)
            {
                _waitCounter = 0f;
                return NodeStatus.Success;
            }
            return NodeStatus.Running;
        }
    }
}
