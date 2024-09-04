using UnityEngine;
using UnityEngine.Assertions;
using JHFBehaviorTree;

namespace Example
{
    public class ActionAttack : Action
    {
        private Animator _animator;
        private BTGuard _guard = null;

        private Transform _lastTarget;
        private EnemyManager _enemyManager;

        public ActionAttack(Transform transform)
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

            _guard.AttackCounter += Time.deltaTime;
            if (_guard.AttackCounter >= BTGuard.ATTACK_TIME)
            {
                _guard.AttackCounter = 0f;
                bool enemyIsDead = _enemyManager.TakeHit();
                if (enemyIsDead)
                {
                    _enemyManager = null;
                }
                return NodeStatus.Success;
            }

            return NodeStatus.Running;
        }

        public override void OnExit()
        {
            _animator.SetBool("Attacking", false);
        }
    }
}
