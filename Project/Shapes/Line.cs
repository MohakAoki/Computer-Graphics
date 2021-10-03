namespace MohakAoki
{
    public struct LineShape
    {
        public Vector2[] points;
        private int count;
        public LineShape (Vector2[] points)
        {
            this.points = points;
            count = points.Length;
        }

        public Vector2 direction => points[1] - points[0];
        public float length => direction.magnitude;
    }
}