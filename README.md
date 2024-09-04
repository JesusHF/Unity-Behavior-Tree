# Simple Behavior Tree system

It suppports behavior tree creation by code, it's easy use, extend and it's completely free 😃.

Class List:
* `BehaviorTree`
* `Node`
  * `Action`
  * `Condition`
  * `SimpleAction`
  * `SimpleCondition`
* `Composite`
  * `RandomSelector`
  * `RandomSequence`
  * `Selector`
  * `Sequence`
* `Decorator`
  * `Delayer`
  * `Interrupter` 
  * `Inverter`

# How to use it
1. Declare it inside the `Monobehavior` where you need it.
```
using JHFBehaviorTree;
...
private BehaviorTree _behaviorTree = null;
```

2. Initialize it inside `Start()` or `Awake()` methods (Example):
```
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
        new Delayer(new ActionPatrol(this.transform, _waypoints), PATROL_WAIT_TIME)
    });

    _behaviorTree = new BehaviorTree(root);
}
```

3. Update in the Update() method:
```
private void Update()
{
  _behaviorTree.UpdateTree();
}
```

4. Enjoy!
