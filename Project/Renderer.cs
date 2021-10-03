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
                if (CheckPixel(pixel, panel))
                    panel.SetPixel(pixel.x, pixel.y, pixel.color);
            }
        }


        public static void Initialize(Vector2 pivot, Size size)
        {
            _pivot = pivot;
            _size = size;
            panel = new Bitmap(size.Width, size.Height);
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
                switch (item.drawMode)
                {
                    case "Line DDA":
                        points.AddRange(DrawSystem.CreateDDALine(item.start, item.end).points);
                        break;
                    case "Line Bresenham":
                        points.AddRange(DrawSystem.CreateBresenhamLine(item.start, item.end).points);
                        break;
                    default:
                        break;
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
    }
}
