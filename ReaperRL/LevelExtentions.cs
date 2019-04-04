using System;
using System.Collections.Generic;
using System.Text;
using TSRL;
using GoRogue;

namespace ReaperRL
{
    enum LayerNames
    {
        TERRAIN,
        ITEMS,
        CREATURES,
    }

    class LevelExtentions
    {
        static public IEnumerable<IInteractable> GetInteractablesAroundLocation(Level l, Coord position)
        {
            Rectangle rect = new Rectangle(position, 1, 1);
            foreach(Coord c in rect.Positions())
            {
                if (l.Terrain[c.X, c.Y] is IInteractable)
                {
                    yield return (IInteractable)l.Terrain[c.X, c.Y];
                }
            }
            foreach (Entity e in l.GetEntitiesInRect(rect, 0))
            {
                if(e.HasComponent<IInteractable>())
                {
                    yield return e.GetComponent<IInteractable>();
                }
            }
        }
        
        static public IEnumerable<IInteractable> GetInteractablesAtLocation(Level l, Coord position)
        {
            if(l.Terrain[position.X, position.Y] is IInteractable)
            {
                yield return (IInteractable)l.Terrain[position.X, position.Y];
            }
            foreach(Entity e in l.GetEntitiesInRect(new Rectangle(position, position), 1))
            {
                if (e.HasComponent<IInteractable>())
                {
                    yield return (IInteractable)e.GetComponents<IInteractable>();
                }
            }
        }
    }
}
