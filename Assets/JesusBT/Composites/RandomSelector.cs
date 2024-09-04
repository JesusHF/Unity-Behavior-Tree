using System.Collections.Generic;

namespace JHFBehaviorTree
{
    public class RandomSelector : Selector
    {
        public RandomSelector(List<Node> children) : base(children) { }

        public override void OnEnter()
        {
            base.OnEnter();
            Helpers.Shuffle(_children);
        }
    }
}
