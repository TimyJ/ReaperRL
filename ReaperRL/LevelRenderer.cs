using TSRL;
using GoRogue;
using BearLib;
using System.Collections.Generic;
using System.Linq;

namespace ReaperRL
{
    class LevelRenderer : IPanel
    {
        GoRogue.BoundedRectangle viewport;
        public int panelWidth { get => viewport.Area.Width;  }
        public int panelHeight { get => viewport.Area.Height; }

        public Level curLevel { get; private set; }

        public LevelRenderer(Level levelToRender) {
            curLevel = levelToRender;
            viewport = new BoundedRectangle(new Rectangle(0, 0, Terminal.State(Terminal.TK_WIDTH) - 15, Terminal.State(Terminal.TK_HEIGHT) - 10), new Rectangle(0, 0, curLevel.MapWidth, curLevel.MapHeight));
        }

        
        public void Draw()
        {
            foreach (Entity e in curLevel.GetEntitiesInRect(viewport.Area, 0))
            {
                if (e.HasComponent(typeof(DisplayInfo))){
                    Terminal.Color(e.GetComponent<DisplayInfo>().color);
                    Terminal.Put(curLevel.EntityPosition(e) - viewport.Area.MinExtent, e.GetComponent<DisplayInfo>().Glyph);
                }
            }
            MessageLog.Draw();
        }

        public bool HandleInput(int key)
        {
            Direction d = Direction.NONE;
            switch (Keybinds.ReturnAction(key))
            {
                case Action.UP:
                    d = Direction.UP;
                    break;
                case Action.DOWN:
                    d = Direction.DOWN;
                    break;
                case Action.LEFT:
                    d = Direction.LEFT;
                    break;
                case Action.RIGHT:
                    d = Direction.RIGHT;
                    break;


                case Action.INTERACT:
                    List<IInteractable> i = LevelExtentions.GetInteractablesAroundLocation(curLevel, curLevel.EntityPosition(curLevel.PlayerCharacter)).ToList<IInteractable>();
                    if(i.Count == 1)
                    {
                        i[0].Interact(curLevel.PlayerCharacter, curLevel);
                    }
                    break;
            }

            if(d != Direction.NONE)
            {
                if(curLevel.MoveEntity(curLevel.PlayerCharacter, d))
                {
                    return true;
                }
            }
            return true;
        }

        public void Resize(int screen_width, int screen_height)
        {
            viewport.Area = new Rectangle(0, 0, Terminal.State(Terminal.TK_WIDTH) - 15, Terminal.State(Terminal.TK_HEIGHT) - 10);
        }
    }
}
