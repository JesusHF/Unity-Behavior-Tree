using System.Collections.Generic;
using UnityEngine;
using Jesushf;

public class BTGuard : BehaviorTree
{
    [SerializeField] private Transform[] _waypoints;
    [HideInInspector] public Transform Target = null;
    [HideInInspector] public float AttackCounter = 0f;

    public static float SPEED { get { return 2f; } }
    public static float FOV_RANGE { get { return 6f; } }
    public static float ATTACK_RANGE { get { return 1f; } }
    public static float ATTACK_TIME { get { return 1f; } }
    public static float PATROL_WAIT_TIME { get { return 1f; } }

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckEnemyInAttackRange(this.transform),
                new TaskAttack(this.transform),
            }),
            new Sequence(new List<Node>
            {
                new CheckEnemyInFOVRange(this.transform),
                new TaskGoToTarget(this.transform),
            }),
            new Sequence(new List<Node>
            {
                new ActionDelay(PATROL_WAIT_TIME),
                new TaskPatrol(this.transform, _waypoints),
            })
        });

        return root;
    }
}
