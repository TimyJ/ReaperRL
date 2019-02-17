using System;
using System.Collections.Generic;
using System.Text;
using BearLib;

namespace TSRL
{
    public class PanelStack
    {
        private List<IPanel> panels;
        
        public PanelStack()
        {
            panels = new List<IPanel>();
        }

        public void AddPanel(IPanel panel)
        {
            panels.Add(panel);
        }

        public void RemovePanel(IPanel panel)
        {
            panels.Remove(panel);
        }

        public void DrawAndInput(int key)
        {
            foreach(IPanel p in panels)
            {
                p.Draw();
            }
            Terminal.Refresh();
            if(panels.Count > 0)
            {
                key = Terminal.Read();
                for(int i = panels.Count - 1; i >= 0; --i)
                {
                    if (!panels[i].HandleInput(key)){ break; }
                }
            }
        }

        public void Resize(int screen_width, int screen_height)
        {
            foreach(IPanel p in panels)
            {
                p.Resize(screen_width, screen_height);
            }
        }
    }
}
