using System;
using System.Collections.Generic;
using System.Text;
using TSRL;

namespace ReaperRL
{
    static class Globals
    {
        static PanelStack panels = new PanelStack();
        static Entity playerCharacter = new Entity();
        static public int currentDay;
        static public int dayTime;

        static public void AddPanel(IPanel panel) {
            panels.AddPanel(panel);
        }

        static public void DrawAndInput()
        {
            panels.DrawAndInput(0);
        }

        static public Entity GetPlayer()
        {
            return playerCharacter;
        }


        
    }
}
