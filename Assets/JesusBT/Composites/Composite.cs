﻿using System.Collections.Generic;

namespace JHFBehaviorTree
{
    public abstract class Composite : Node
    {
        protected List<Node> _children = new();

        public Composite(List<Node> children) : base()
        {
            foreach (Node child in children)
            {
                child.SetParent(this);
                _children.Add(child);
            }
        }

        public override void Restart()
        {
            base.Restart();
            foreach (Node child in _children)
            {
                child.Restart();
            }
        }
    }
}
