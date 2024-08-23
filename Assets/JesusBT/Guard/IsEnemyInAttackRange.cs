using UnityEngine;

namespace Jesushf
{
    public class IsEnemyInAttackRange : Condition
    {
        private Transform _transform;

        public IsEnemyInAttackRange(Transform transform)
        {
            _transform = transform;
        }

        public override NodeStatus OnUpdate()
        {
            BTGuard guard = _transform.GetComponent<BTGuard>();
            Transform target = guard.Target;
            if (target == null)
            {
                return NodeStatus.Failure;
            }

            if (Vector3.Distance(_transform.position, target.position) <= BTGuard.ATTACK_RANGE)
            {
                return NodeStatus.Success;
            }

            return NodeStatus.Failure;
        }
    }
}
