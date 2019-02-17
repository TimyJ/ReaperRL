using System;
using System.Drawing;
using BearLib;
using TSRL;

namespace ReaperRL
{
    class Program
    {
        static void Main(string[] args)
        {
            WindowUtilities.OpenWindow();
            Level l = new Level(96, 96, 2);
            LevelRenderer levelRenderer = new LevelRenderer(l);
            Entity player = new Entity();
            player.AddComponent<DisplayInfo>(new DisplayInfo(player, '@', Color.White));
            l.EnterLevel(player);

            Globals.AddPanel(levelRenderer);

            while (true)
            {
                Terminal.Clear();
                Globals.DrawAndInput();
                Terminal.Refresh();
            }
        }


    }
}
