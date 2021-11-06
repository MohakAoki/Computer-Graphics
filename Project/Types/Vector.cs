using System;

namespace MohakAoki
{
    /// <summary>
    /// The base type for using positions and vectors
    /// </summary>
    public struct Vector2
    {
        /// <summary>
        /// x-axis (left-right) position.
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// y-axis (down-up) position
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// The Length of vector. it's <see cref="X"/>² times <see cref="Y"/>² under √
        /// </summary>
        public float magnitude => MathF.Sqrt(X * X + Y * Y);

        /// <summary>
        /// The Normal of vector. a vector Parallel main vector but in <see cref="magnitude"/> of 1
        /// </summary>
        public Vector2 normal => new Vector2((int)Math.Round(X / magnitude), (int)Math.Round(Y / magnitude));

        /// <summary>
        /// Vector2 (0,0)
        /// </summary>
        public static Vector2 zero => new Vector2(0, 0);
        /// <summary>
        /// Vector2 (1,0)
        /// </summary>
        public static Vector2 right => new Vector2(1, 0);
        /// <summary>
        /// Vector2 (0,1)
        /// </summary>
        public static Vector2 up => new Vector2(0, 1);
        /// <summary>
        /// Vector2 (1,1)
        /// </summary>
        public static Vector2 one => new Vector2(1, 1);

        /// <summary>
        /// Constructor of Vector
        /// </summary>
        /// <param name="x">position on x axis</param>
        /// <param name="y">position on y axis</param>
        public Vector2(int x, int y) { X = x; Y = y; }

        /// <summary>
        /// Constructor of Vector
        /// </summary>
        /// <param name="x">position on x axis</param>
        /// <param name="y">position on y axis</param>
        public Vector2(decimal x, decimal y)
        {
            X = (int)x;
            Y = (int)y;
        }
        /// <summary>
        /// Vector2 (0, <seealso cref="Y"/>)
        /// </summary>
        /// <returns>a vector</returns>
        public Vector2 UpOnly() => new Vector2(0, Y);
        /// <summary>
        /// Vector2 (<see cref="X"/>, 0)
        /// </summary>
        /// <returns>a vector</returns>
        public Vector2 RightOnly() => new Vector2(X, 0);

        /// <summary>
        /// Rotate this vector Around <paramref name="pivot"/> by <paramref name="degree"/> counter clockwise
        /// </summary>
        /// <param name="pivot">position of pivot to rotate around</param>
        /// <param name="degree">the amount of rotation base on degree</param>
        public void Rotate(Vector2 pivot, int degree)
        {
            this = Vector2.RotateAround(this, pivot, degree);
        }
        /// <summary>
        /// Rotate <paramref name="point"/> Around <paramref name="pivot"/> by <paramref name="degree"/> counter clockwise
        /// </summary>
        /// <param name="pivot">position of pivot to rotate around</param>
        /// <param name="degree">the amount of rotation base on degree</param>
        /// <param name="point">The point that will rotate around <paramref name="pivot"/></param>
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