namespace MohakAoki
{
    public struct Eclipse
    {
        public Vector2 offset;
        public Vector2 ab;
        public Vector2[] points;

        public Eclipse(Vector2 offset, Vector2 ab, Vector2[] points)
        {
            this.offset = offset;
            this.ab = ab;
            this.points = points;
        }
        public Eclipse(Vector2 offset, Vector2 ab)
        {
            this.offset = offset;
            this.ab = ab;
            this.points = DrawSystem.CreateEclipse(offset, ab).points;
        }
    }
}