using TSRL;
using GoRogue;
using BearLib;

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
            /*
            foreach(Coord c in viewport.Area.Positions())
            {
                Terminal.Put(c, curLevel.Terrain[c.X, c.Y].Glyph);
            }
            */
            foreach (Entity e in curLevel.GetEntitiesInRect(viewport.Area, 0))
            {
                if (e.HasComponent(typeof(DisplayInfo))){
                    Terminal.Color(e.GetComponent<DisplayInfo>().color);
                    Terminal.Put(curLevel.EntityPosition(e) - viewport.Area.MinExtent, e.GetComponent<DisplayInfo>().Glyph);
                }
            }
        }

        public bool HandleInput(int key)
        {
            return false;
        }

        public void Resize(int screen_width, int screen_height)
        {
            viewport.Area = new Rectangle(0, 0, Terminal.State(Terminal.TK_WIDTH) - 15, Terminal.State(Terminal.TK_HEIGHT) - 10);
        }
    }
}
