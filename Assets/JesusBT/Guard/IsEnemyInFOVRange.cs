using UnityEngine;

namespace Jesushf
{
    public class IsEnemyInFOVRange : Condition
    {
        private static int _enemyLayerMask = 1 << 6;

        private Transform _transform;
        private Animator _animator;

        public IsEnemyInFOVRange(Transform transform)
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
                Collider[] colliders = Physics.OverlapSphere(_transform.position, BTGuard.FOV_RANGE, _enemyLayerMask);
                if (colliders.Length > 0)
                {
                    guard.Target = colliders[0].transform;
                    _animator.SetBool("Walking", true);
                    return NodeStatus.Success;
                }

                return NodeStatus.Failure;
            }

            return NodeStatus.Success;
        }
    }
}
