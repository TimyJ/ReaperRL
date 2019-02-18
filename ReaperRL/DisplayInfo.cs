using System;
using System.Collections.Generic;
using System.Drawing;
using TSRL;

namespace ReaperRL
{
    class DisplayInfo
    {
        public int Glyph { get; }
        public Color color { get; }
        public Entity Owner { get; private set; }

        public DisplayInfo(Entity owner, int glyph, Color c)
        {
            Glyph = glyph;
            color = c;
            Owner = owner;
        }
    }
}
