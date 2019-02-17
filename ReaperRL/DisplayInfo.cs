using System;
using System.Collections.Generic;
using System.Drawing;
using TSRL;

namespace ReaperRL
{
    class DisplayInfo : Component
    {
        public int Glyph { get; }
        public Color color { get; }

        public DisplayInfo(Entity owner, int glyph, Color c) : base(owner)
        {
            Glyph = glyph;
            color = c;
        }
    }
}
