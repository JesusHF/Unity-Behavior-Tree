using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Jesushf;

public class BTGuard : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [HideInInspector] public Transform Target = null;
    [HideInInspector] public float AttackCounter = 0f;
    private BehaviorTree _behaviorTree = null;

    public static float SPEED { get { return 2f; } }
    public static float FOV_RANGE { get { return 6f; } }
    public static float ATTACK_RANGE { get { return 1f; } }
    public static float ATTACK_TIME { get { return 1f; } }
    public static float PATROL_WAIT_TIME { get { return 1f; } }

    private void Awake()
    {
        SimpleCondition isEnemyInAttackRange = new SimpleCondition(() => IsEnemyInAttackRange(Target));

        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                isEnemyInAttackRange,
                new ActionAttack(this.transform),
            }),
            new Sequence(new List<Node>
            {
                new IsEnemyInFOVRange(this.transform),
                new ActionGoToTarget(this.transform),
            }),
            new Sequence(new List<Node>
            {
                new Delayer(new ActionPatrol(this.transform, _waypoints), PATROL_WAIT_TIME),
            })
        });

        Assert.IsNotNull(root);
        _behaviorTree = new BehaviorTree(root);
        Assert.IsNotNull(_behaviorTree);
    }

    private void Update()
    {
        _behaviorTree.UpdateTree();
    }

    private bool IsEnemyInAttackRange(Transform enemy)
    {
        if (enemy == null)
        {
            return false;
        }
        float distance = Vector3.Distance(enemy.position, this.transform.position);
        return distance <= ATTACK_RANGE;
    }
}
