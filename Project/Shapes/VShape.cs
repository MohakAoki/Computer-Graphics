using System.Collections.Generic;

namespace MohakAoki
{
    public struct VShape
    {
        public LineShape a, b;
        public VShape (LineShape a, LineShape b)
        {
            this.a = a;
            this.b = b;
        }

        public Vector2[] GetAllPoints()
        {
            List<Vector2> points = new List<Vector2>();
            points.AddRange(a.points);
            points.AddRange(b.points);
            return points.ToArray();
        }
    }
}