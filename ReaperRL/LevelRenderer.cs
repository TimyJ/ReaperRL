﻿using TSRL;
using GoRogue;
using BearLib;

namespace ReaperRL
{
    class LevelRenderer : IPanel
    {
        GoRogue.BoundedRectangle viewport;
        public int panelWidth { get => viewport.Area.Width;  }
        public int panelHeight { get => viewport.Area.Height; }

        Level curLevel;

        public LevelRenderer(Level levelToRender) {
            curLevel = levelToRender;
            viewport = new BoundedRectangle(new Rectangle(0, 0, Terminal.State(Terminal.TK_WIDTH) - 15, Terminal.State(Terminal.TK_HEIGHT) - 10), new Rectangle(0, 0, curLevel.MapWidth, curLevel.MapHeight));
        }

        
        public void Draw()
        {
            foreach (Entity e in curLevel.GetEntitiesInRect(viewport.Area, 0))
            {
                if (e.HasComponents(typeof(DisplayInfo))){
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
