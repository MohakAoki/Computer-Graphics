namespace MohakAoki
{
    public struct CircleShape
    {
        public Vector2 pivot;
        public int radious;
        public Vector2[] points;

        public CircleShape(Vector2 pivot, int radious, Vector2[] points)
        {
            this.pivot = pivot;
            this.radious = radious;
            this.points = points;
        }
        public CircleShape(Vector2 pivot, int radious)
        {
            this.pivot = pivot;
            this.radious = radious;
            this.points = DrawSystem.CreateCircle(pivot, radious).points;
        }
    }
}