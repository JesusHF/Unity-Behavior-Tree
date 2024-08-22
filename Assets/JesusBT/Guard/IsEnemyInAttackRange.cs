using UnityEngine;

namespace Jesushf
{
    public class IsEnemyInAttackRange : Condition
    {
        private Transform _transform;
        private Animator _animator;

        public IsEnemyInAttackRange(Transform transform)
        {
            _transform = transform;
            _animator = transform.GetComponent<Animator>();
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
                _animator.SetBool("Attacking", true);
                _animator.SetBool("Walking", false);

                return NodeStatus.Success;
            }

            return NodeStatus.Failure;
        }
    }
}
