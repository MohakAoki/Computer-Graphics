using System;
using System.Drawing;
using System.Collections.Generic;

namespace MohakAoki
{
    public class Renderer
    {
        private static Bitmap panel;

        private static List<DrawItem> itemsToDraw = new List<DrawItem>();
        protected static Vector2 _pivot;
        protected static PointF _ratio;
        protected static Size _size;
        public static Vector2 pivot => _pivot;
        public static PointF ratio => _ratio;
        public static Size size => _size;

        private static Action OnRender;

        private static void Render()
        {
            if (panel != null)
            {
                panel.Dispose();
            }
            panel = new Bitmap(size.Width, size.Height);
            List<Pixel> pixels = new List<Pixel>();
            pixels.AddRange(CreatePanel(size, pivot, true));
            pixels.AddRange(CreateItems(itemsToDraw.ToArray()));

            foreach (Pixel pixel in pixels)
            {
                DrawPixel(pixel, ref panel);
            }
        }


        public static void Initialize(Vector2 pivot, Size size)
        {
            _size = size;
            _pivot = pivot;
            OnRender += Render;
        }
        public static void Initialize(int pivotX, int pivotY, int sizeWidth, int sizeHeight)
        {
            Initialize(new Vector2(pivotX, pivotY), new Size(sizeWidth, sizeHeight));
        }
        public static void SetRatio(PointF ratio)
        {
            _ratio = ratio;
        }
        public static void SetRatio(float xRatio, float yRatio)
        {
            SetRatio(new PointF(xRatio, yRatio));
        }
        public static void CalculateRatio()
        {
            _ratio.X = (float)_pivot.X / _size.Width;
            _ratio.Y = (float)_pivot.Y / _size.Height;
        }
        public static void SetSize(Size size)
        {
            _size = size;
        }
        public static void SetSize(int width, int height)
        {
            SetSize(new Size(width, height));
        }
        public static void SetPivot(Vector2 pivot)
        {
            _pivot = pivot;
        }
        public static void SetPivot(int x, int y)
        {
            SetPivot(new Vector2(x, y));
        }
        public static Bitmap GetRender()
        {
            OnRender.Invoke();
            return panel;
        }
        public static void AddItemsToDraw(DrawItem[] items, bool keepPrevous)
        {
            if (!keepPrevous)
                itemsToDraw.Clear();
            itemsToDraw.AddRange(items);
        }
        public static Vector2[] CalculateTransform(DrawItem baseItem, Transform.Trans[] trans)
        {
            Matrix[] matrices = new Matrix[trans.Length];
            Matrix t;
            for (int i = trans.Length - 1; i >= 0; i--)
            {
                t = Matrix.Identity(3);
                switch (trans[i].type)
                {
                    case Transform.TransType.Pos:
                        t.SetItem(0, 2, trans[i].data.X);
                        t.SetItem(1, 2, trans[i].data.Y);
                        break;
                    case Transform.TransType.Rot:
                        float rad = (float)Math.PI * trans[i].data.X / 180;
                        t.SetItem(0, 0, MathF.Cos(rad));
                        t.SetItem(0, 1, -MathF.Sin(rad));
                        t.SetItem(1, 0, MathF.Sin(rad));
                        t.SetItem(1, 1, MathF.Cos(rad));
                        break;
                    case Transform.TransType.Sca:
                        t.SetItem(0, 0, trans[i].data.X);
                        t.SetItem(1, 1, trans[i].data.Y);
                        break;
                    default:
                        break;
                }
                matrices[trans.Length - 1 - i] = t;
            }
            Matrix M = CalculateMatrices(matrices);
            List<Vector2> points = new List<Vector2>();
            switch (baseItem.drawMode)
            {
                case "Line DDA":
                    points.AddRange(DrawSystem.CreateDDALine(baseItem.start, baseItem.end).points);
                    break;
                case "Line Bresenham":
                    points.AddRange(DrawSystem.CreateBresenhamLine(baseItem.start, baseItem.end).points);
                    break;
                case "Circle":
                    points.AddRange(DrawSystem.CreateCircle(baseItem.start, baseItem.end.X).points);
                    break;
                case "Eclipse x²/a² + y²/b² = 1":
                    points.AddRange(DrawSystem.CreateEclipse(baseItem.start, baseItem.end).points);
                    break;
                default:
                    break;
            }
            Matrix P = new Matrix(3, points.Count);
            for (int i = 0; i < points.Count; i++)
            {
                P.SetItem(0, i, points[i].X);
                P.SetItem(1, i, points[i].Y);
                P.SetItem(2, i, 1);
            }
            if (M != null)
            {
                Matrix res = M.Multiply(P);
                System.Windows.Forms.MessageBox.Show(M.ToString());
                System.Windows.Forms.MessageBox.Show(P.ToString());
                System.Windows.Forms.MessageBox.Show(res.ToString());
                points.Clear();
                for (int i = 0; i < res.Columns; i++)
                {
                    points.Add(new Vector2(
                        (int)res.GetItem(0, i),
                        (int)res.GetItem(1, i)));
                }
            }
            return points.ToArray();
        }


        private static Pixel[] CreatePanel(Size _size, Vector2 _pivot, bool drawArrows)
        {
            List<Pixel> points = new List<Pixel>();
            Vector2 offset = new Vector2(
                _size.Width / 2 - _pivot.X,
                _size.Height / 2 - pivot.Y
                );
            for (int i = 0; i < _size.Width; i++)
            {
                for (int j = 0; j < _size.Height; j++)
                {
                    points.Add(new Pixel(i, j, Color.Black));
                }
            }
            LineShape verticalLine, horizontalLine;

            verticalLine = DrawSystem.CreateDDALine(Vector2.up * (_size.Height / 2 - 1), -Vector2.up * (_size.Height / 2));
            for (int i = 0; i < verticalLine.points.Length; i++)
            {
                verticalLine.points[i] += offset.UpOnly();
            }
            horizontalLine = DrawSystem.CreateDDALine(Vector2.right * (_size.Width / 2 - 1), -Vector2.right * (_size.Width / 2));
            for (int i = 0; i < horizontalLine.points.Length; i++)
            {
                horizontalLine.points[i] += offset.RightOnly();
            }
            points.AddRange(VectorsToPixel(verticalLine.points, Color.Green));
            points.AddRange(VectorsToPixel(horizontalLine.points, Color.Green));

            if (drawArrows)
            {
                VShape verticalArrow, horizontalArrow;

                verticalArrow = DrawSystem.CreateArrow(Vector2.zero, Vector2.up * (_size.Height / 2 - 1) + offset.UpOnly(), size.Height / 20);
                points.AddRange(VectorsToPixel(verticalArrow.GetAllPoints(), Color.Green));

                horizontalArrow = DrawSystem.CreateArrow(Vector2.zero, Vector2.right * (_size.Width / 2 - 1) + offset.RightOnly(), size.Width / 20);
                points.AddRange(VectorsToPixel(horizontalArrow.GetAllPoints(), Color.Green));
            }

            return points.ToArray();
        }
        private static Pixel[] CreateItems(DrawItem[] items)
        {
            List<Pixel> pixels = new List<Pixel>();
            List<Vector2> points = new List<Vector2>();
            foreach (DrawItem item in items)
            {
                points.Clear();
                if (item.transform != null)
                {
                    points.AddRange(CalculateTransform(item, item.transform.transforms.ToArray()));
                }
                else
                {
                    switch (item.drawMode)
                    {
                        case "Line DDA":
                            points.AddRange(DrawSystem.CreateDDALine(item.start, item.end).points);
                            break;
                        case "Line Bresenham":
                            points.AddRange(DrawSystem.CreateBresenhamLine(item.start, item.end).points);
                            break;
                        case "Circle":
                            points.AddRange(DrawSystem.CreateCircle(item.start, item.end.X).points);
                            break;
                        case "Eclipse x²/a² + y²/b² = 1":
                            points.AddRange(DrawSystem.CreateEclipse(item.start, item.end).points);
                            break;
                        default:
                            break;
                    }
                }
                pixels.AddRange(VectorsToPixel(points.ToArray(), item.color));
            }
            return pixels.ToArray();
        }
        private static void DrawPixel(Pixel pixel, ref Bitmap panel)
        {
            if (CheckPixel(pixel, panel))
                panel.SetPixel(pixel.x, pixel.y, pixel.color);
        }
        private static bool CheckPixel(Pixel pixel, Bitmap refmap)
        {
            if (pixel.x < 0 || pixel.y < 0 || pixel.x > refmap.Width - 1 || pixel.y > refmap.Height - 1)
                return false;
            return true;
        }
        private static Pixel VectorToPixel(Vector2 vector, Color color)
        {
            return new Pixel(vector.X + pivot.X, vector.Y + pivot.Y, color);
        }
        private static Pixel[] VectorsToPixel(Vector2[] vectors, Color color)
        {
            Pixel[] pixels = new Pixel[vectors.Length];
            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = VectorToPixel(vectors[i], color);
            }
            return pixels;
        }
        private static Matrix CalculateMatrices(Matrix[] matrices)
        {
            if (matrices.Length == 0)
            {
                return null;
            }
            if (matrices.Length < 2)
            {
                return matrices[0];
            }

            Matrix result = matrices[0];
            for (int i = 1; i < matrices.Length; i++)
            {
                result = result.Multiply(matrices[i]);
            }
            return result;
        }
    }
}
