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
            Level testLevel = new Level(96, 96, 2);
            LevelRenderer levelRenderer = new LevelRenderer(testLevel);
            Entity player = new Entity();
            DisplayInfo d = new DisplayInfo(player, '@', Color.White);
            player.AddComponent(d);
            testLevel.EnterLevel(player);

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
