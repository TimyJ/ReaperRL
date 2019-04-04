using System.Drawing;
using GoRogue;

namespace TSRL
{
    public class TerrainBase
    {
        public string Name { get; private set; }
        public bool Blocks { get; private set; }
        public int Glyph { get; private set; }
        public Color Foreground { get; private set; }
        public Color Background { get; private set; }

        public TerrainBase(string name, bool blocks, int glyph, Color foreground, Color background)
        {
            Name = name;
            Blocks = blocks;
            Glyph = glyph;
            Foreground = foreground;
            Background = background;
        }
    }
}
