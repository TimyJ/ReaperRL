using System;
using System.Collections.Generic;
using System.Drawing;
using BearLib;

namespace ReaperRL
{
    static class MessageLog
    {
        public static List<String> MESSAGES = new List<string>();
        private static int idx;
        static public void AddMessage(string message)
        {
            MESSAGES.Add(message);
        }

        static public void ClearMore()
        {
            if (MESSAGES.Count > idx)
            {
                idx = Math.Min(3 + idx, MESSAGES.Count - 1);
            }
        }
        static public void Draw()
        {
            BearLib.Terminal.ClearArea(new Rectangle(0, Terminal.State(Terminal.TK_HEIGHT) - 10, Terminal.State(Terminal.TK_WIDTH),
                10));
            for (int y=0; y < Math.Min(9, MESSAGES.Count); ++y)
            {
                Terminal.Color(Color.White);
                Terminal.Print(1, Terminal.State(Terminal.TK_HEIGHT)-y-1, MESSAGES[MESSAGES.Count - y-1]);
            }
        }
    }
}
