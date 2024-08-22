using UnityEngine;
using UnityEngine.Assertions;

namespace Jesushf
{
    public class TaskAttack : Action
    {
        private Animator _animator;
        private BTGuard _guard = null;

        private Transform _lastTarget;
        private EnemyManager _enemyManager;

        private float _attackTime = 1f;
        private float _attackCounter = 0f;

        public TaskAttack(Transform transform)
        {
            _animator = transform.GetComponent<Animator>();
            _guard = transform.GetComponent<BTGuard>();
            Assert.IsNotNull(_animator);
            Assert.IsNotNull(_guard);
        }

        public override void OnEnter()
        {
            _animator.SetBool("Walking", false);
            _animator.SetBool("Attacking", true);
        }

        public override NodeStatus OnUpdate()
        {
            Transform target = _guard.Target;
            if (target != _lastTarget)
            {
                _enemyManager = target.GetComponent<EnemyManager>();
                _lastTarget = target;
            }

            _attackCounter += Time.deltaTime;
            if (_attackCounter >= _attackTime)
            {
                bool enemyIsDead = _enemyManager.TakeHit();
                if (enemyIsDead)
                {
                    return NodeStatus.Success;
                }
                else
                {
                    _attackCounter = 0f;
                }
            }

            return NodeStatus.Running;
        }

        public override void OnExit()
        {
            _animator.SetBool("Attacking", false);
        }
    }
}