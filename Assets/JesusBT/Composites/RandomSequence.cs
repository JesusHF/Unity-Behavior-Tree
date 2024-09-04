using System.Collections.Generic;

namespace JHFBehaviorTree
{
    public class RandomSequence : Sequence
    {
        public RandomSequence(List<Node> children) : base(children) { }

        public override void OnEnter()
        {
            base.OnEnter();
            Helpers.Shuffle(_children);
        }
    }
}
