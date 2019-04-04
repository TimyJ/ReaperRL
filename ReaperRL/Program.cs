using System;
using System.Drawing;
using System.Linq;
using BearLib;
using TSRL;
using ReaperRL.Components;
using GoRogue;

namespace ReaperRL
{
    class Program
    {
        static void Main(string[] args)
        {
            WindowUtilities.OpenWindow();
            LayerMasker mask = new LayerMasker(3);
            Level testLevel = new Level(96, 96, 2, mask.Mask((int)LayerNames.ITEMS));
            LevelRenderer levelRenderer = new LevelRenderer(testLevel);
            Entity player = new Entity();
            DisplayInfo d = new DisplayInfo(player, '@', Color.White);
            player.AddComponent(d);
            ToolQualities t = new ToolQualities();
            player.AddComponent(t);
            testLevel.EnterLevel(player);
            Entity tree = new Entity();
            tree.AddComponent(new DisplayInfo(tree, '|', Color.ForestGreen));
            tree.AddComponent(new Tree(tree));
            testLevel.Add(tree, (4, 4));
            Globals.AddPanel(levelRenderer);
            MessageLog.AddMessage("Press ? for help");

            while (true)
            {
                Terminal.Clear();
                Globals.DrawAndInput();
                Terminal.Refresh();
            }
        }


    }
}
