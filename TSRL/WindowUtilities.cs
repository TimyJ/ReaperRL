using GoRogue;
using BearLib;

namespace TSRL
{
    static public class WindowUtilities
    {
        static public void OpenWindow()
        {
            Terminal.Open();
            //string windowSize = Terminal.Get("ini.Terminal.window.size", "80x40");
            //Terminal.Set(windowSize);
            //string windowName = Terminal.Get("ini.Terminal.window.name", "R");
            //Terminal.Set(windowName);
            //string font = Terminal.Get("ini.Terminal.Font", "");
            //Terminal.Set(font);
            Terminal.Print(1, 1, "Hello World!");
            Terminal.Refresh();
        }

        static public Coord GetWindowCenter()
        {
            return new Coord(Terminal.State(Terminal.TK_WIDTH) / 2, Terminal.State(Terminal.TK_HEIGHT) / 2);
        }
    }
}
