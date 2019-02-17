using System;
using System.Collections.Generic;
using System.Text;

namespace TSRL
{
    public abstract class Component
    {
        public Entity Owner;

        public Component(Entity owner)
        {
            Owner = owner;
        }
    }
}
