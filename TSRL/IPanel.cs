using System;
using BearLib;


namespace TSRL
{
    public interface IPanel
    {
        int panelWidth { get; }
        int panelHeight { get; }
        void Draw();
        bool HandleInput(int key);
        void Resize(int screen_width, int screen_height);
    }
}
