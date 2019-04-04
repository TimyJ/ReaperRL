using System;
using System.Collections.Generic;
using GoRogue;
using TSRL;

namespace ReaperRL
{
    interface IInteractable
    {
        bool Interact(Entity e, Level l);
    }
}
