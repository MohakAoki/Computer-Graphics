using System.Drawing;

namespace MohakAoki
{
    public struct DrawItem
    {
        public string drawMode;
        public Vector2 start;
        public Vector2 end;
        public Color color;
        public DrawItem(string drawMode, Vector2 start, Vector2 end, Color color)
        {
            this.drawMode = drawMode;
            this.start = start;
            this.end = end;
            this.color = color;
        }

        public override string ToString()
        {
            return string.Format("{0} from {1} to {2}", drawMode, start, end);
        }
    }
}