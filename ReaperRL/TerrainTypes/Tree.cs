using System;
using GoRogue;
using System.Drawing;
using TSRL;
using ReaperRL.Components;

namespace ReaperRL
{
    class Tree : IInteractable
    {
        private int HP = 3;
        public Coord Position { get; private set; }
        public Entity Owner { get; private set; }

        public Tree(Entity owner)
        {
            Owner = owner;
        }

        public bool Interact(Entity e, Level l)
        {
            if (e.HasComponent<ToolQualities>())
            {
                HP -= e.GetComponent<ToolQualities>().WoodCutting;
                if (HP <= 0)
                {
                    l.RemoveEntity(Owner);
                    MessageLog.AddMessage("You cut down the tree");
                    //TODO: spawn items here or add to player inventory.
                    return true;
                }
                MessageLog.AddMessage("You hack at the tree");
            }
            return false;
        }
    }
}
