using System;

namespace MohakAoki
{
    public struct Vector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public float magnitude => MathF.Sqrt(X * X + Y * Y);
        public Vector2 normal => new Vector2((int)Math.Round(X / magnitude), (int)Math.Round(Y / magnitude));


        public static Vector2 zero => new Vector2(0, 0);
        public static Vector2 right => new Vector2(1, 0);
        public static Vector2 up => new Vector2(0, 1);
        public static Vector2 one => new Vector2(1, 1);

        public Vector2(int x, int y) { X = x; Y = y; }
        public Vector2(decimal x, decimal y)
        {
            X = (int)x;
            Y = (int)y;
        }
        public Vector2 UpOnly() => new Vector2(0, Y);
        public Vector2 RightOnly() => new Vector2(X, 0);
        public void Rotate(Vector2 pivot, int degree)
        {
            this = Vector2.RotateAround(this, pivot, degree);
        }
        public static Vector2 RotateAround(Vector2 point, Vector2 pivot, int degree)
        {
            double _radian = Math.PI * degree / 180;
            point -= pivot;
            Vector2 rotatedVec = new Vector2(
                (int)(point.X * Math.Cos(_radian) - point.Y * Math.Sin(_radian)),
                (int)(point.X * Math.Sin(_radian) + point.Y * Math.Cos(_radian)));

            rotatedVec += pivot;
            return rotatedVec;
        }
        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.X + b.X, a.Y + b.Y);
        public static Vector2 operator *(Vector2 a, int b) => new Vector2(a.X * b, a.Y * b);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.X - b.X, a.Y - b.Y);
        public static Vector2 operator -(Vector2 a) => new Vector2(-a.X, -a.Y);
        public static bool operator ==(Vector2 a, Vector2 b) => (a.X == b.X) && (a.Y == b.Y);
        public static bool operator !=(Vector2 a, Vector2 b) => (a.X != b.X) || (a.Y != b.Y);
        public override bool Equals(object obj)
        {
            if (((Vector2)obj).X == this.X && ((Vector2)obj).Y == this.Y)
                return true;
            return false;
        }
        public override string ToString()
        {
            return string.Format("({0} , {1})", X, Y);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}