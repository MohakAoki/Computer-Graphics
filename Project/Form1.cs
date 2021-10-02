using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        private enum LineType
        {
            StepOnX,
            StepOnY
        }
        private enum DrawElement
        {
            Line,
            Circle
        }
        Vector2 pivot;
        Size size;
        PointF ratio;
        List<DrawItem> itemsToDraw = new List<DrawItem>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Initialize()
        {
            size.Width = (int)numeric_width.Value;
            size.Height = (int)numeric_height.Value;
            pivot.X = (int)pivot_X.Value;
            pivot.Y = (int)pivot_Y.Value;

            comboBox1.SelectedIndex = 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Initialize();
            timer1.Enabled = true;
            timer1.Start();
        }
        private void LineAnalys(Vector2 _start, Vector2 _end, out float m, out LineType _type)
        {
            m = (float)(_end.Y - _start.Y) / (_end.X - _start.X);
            _type = (Math.Abs(m) <= 1) ? LineType.StepOnX : LineType.StepOnY;
        }
        private Vector2[] DrawDDA(Vector2 _start, Vector2 _end)
        {
            float m = 0;
            LineType type = LineType.StepOnX;
            LineAnalys(_start, _end, out m, out type);

            //--------------------------------------------------------------------
            List<Vector2> points = new List<Vector2>();
            points.Add(_start);

            Vector2 _tPoint = _start;
            float _tAxis = 0;
            int _sign = 0;
            if (type.Equals(LineType.StepOnX))
            {
                _sign = Math.Sign(_end.X - _start.X);
                _tAxis = _tPoint.Y;
                do
                {
                    _tPoint.X += _sign;
                    _tAxis += m * _sign;
                    _tPoint.Y = (int)Math.Round(_tAxis);
                    points.Add(_tPoint);
                } while (_tPoint != _end);
            }
            else
            {
                _sign = Math.Sign(_end.Y - _start.Y);
                _tAxis = _tPoint.X;
                do
                {
                    _tPoint.Y += _sign;
                    _tAxis += _sign / m;
                    _tPoint.X = (int)Math.Round(_tAxis);
                    points.Add(_tPoint);
                } while (_tPoint != _end);
            }

            points.Add(_end);
            return points.ToArray();
        }

        private Bitmap CreatePanel(Size _size, Vector2 _pivot)
        {
            Bitmap panel = new Bitmap(_size.Width, _size.Height);
            for (int i = 0; i < _size.Width; i++)
            {
                for (int j = 0; j < _size.Height; j++)
                {
                    panel.SetPixel(i, j, Color.Black);
                }
            }
            for (int i = 0; i < _size.Width; i++)
            {
                panel.SetPixel(i, _pivot.Y, Color.Green);
            }
            for (int i = 0; i < _size.Height; i++)
            {
                panel.SetPixel(_pivot.X, i, Color.Green);
            }

            return panel;
        }
        Vector2[] CreateArrows(Vector2 _from, Vector2 _to, int size)
        {
            List<Vector2> arrows = new List<Vector2>();
            arrows.Add(_from);
            arrows.Add(_to);

            Vector2 _temp = _to - _from;
            _temp = _temp.normal;
            _temp = _to - _temp * size;
            _temp.Rotate(_to, 45);
            arrows.AddRange(DrawDDA(_to, _temp));
            _temp.Rotate(_to, -90);
            arrows.AddRange(DrawDDA(_to, _temp));
            return arrows.ToArray();
        }
        private void ResizePanel(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(Button) && !liveChange.Checked)
                return;

            pivot_X.Maximum = numeric_width.Value;
            pivot_Y.Maximum = numeric_height.Value;
            if (!liveChange.Checked)
            {
                ratio.X = (float)pivot.X / size.Width;
                ratio.Y = (float)pivot.Y / size.Height;
            }
            //MessageBox.Show(string.Format("Size: {0} \nPivot: {1}\nratio: {2}", size, pivot, ratio));
            size.Width = (int)numeric_width.Value;
            size.Height = (int)numeric_height.Value;

            if (size.Width < pivot_X.Value || keepRatio.Checked)
            {
                pivot_X.Value = (int)MathF.Round(size.Width * ratio.X);
            }
            if (size.Height < pivot_Y.Value || keepRatio.Checked)
            {
                pivot_Y.Value = (int)MathF.Round(size.Height * ratio.Y);
            }
            pivot.X = (int)pivot_X.Value;
            pivot.Y = (int)pivot_Y.Value;
        }

        private void liveChange_CheckedChanged(object sender, EventArgs e)
        {
            btnResize.Enabled = !liveChange.Checked;
            btn_setPivot.Enabled = !liveChange.Checked;

            ratio.X = (float)pivot.X / size.Width;
            ratio.Y = (float)pivot.Y / size.Height;
        }

        private void SetPivot(object sender, EventArgs e)
        {
            pivot.X = (int)pivot_X.Value;
            pivot.Y = (int)pivot_Y.Value;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap panel = CreatePanel(size, pivot);
            List<Vector2> points = new List<Vector2>();
            points.AddRange(CreateArrows(Vector2.zero, Vector2.right * (size.Width - pivot.X - 1), size.Width / 20));
            points.AddRange(CreateArrows(Vector2.zero, Vector2.up * (size.Height - pivot.Y - 1), size.Height / 20));
            for (int i = 0; i < points.Count; i++)
            {
                //MessageBox.Show((points[i].X).ToString());
                panel.SetPixel(pivot.X + points[i].X, pivot.Y + points[i].Y, Color.Green);
            }
            points.Clear();
            for (int i = 0; i < itemsToDraw.Count; i++)
            {
                switch (itemsToDraw[i].drawMode)
                {
                    case "Line DDA":
                        points.AddRange(DrawDDA(itemsToDraw[i].start, itemsToDraw[i].end));
                        break;

                    default:
                        break;
                }
                lb_debug.Text = points.Count + " point to draw";
                for (int j = 0; j < points.Count; j++)
                {
                    panel.SetPixel(pivot.X + points[j].X, pivot.Y + points[j].Y, itemsToDraw[i].color);
                }
                points.Clear();
            }
            pictureBox1.Image = panel;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawElement _drawElement;
            if (comboBox1.SelectedItem.ToString() == "Circle")
            {
                _drawElement = DrawElement.Circle;
            }
            else
            {
                _drawElement = DrawElement.Line;
            }
            ShowHideDrawElements(_drawElement);
        }

        private void ShowHideDrawElements(DrawElement drawElement)
        {
            switch (drawElement)
            {
                case DrawElement.Line:
                    pointAWidth.Visible = true;
                    pointAHeight.Visible = true;
                    pointBWidth.Visible = true;
                    pointBHeight.Visible = true;
                    lb_firstData.Text = "Point A";
                    lb_secondData.Text = "Point B";
                    break;
                case DrawElement.Circle:
                    pointAWidth.Visible = true;
                    pointAHeight.Visible = true;
                    pointBWidth.Visible = true;
                    pointBHeight.Visible = false;
                    pointBHeight.Value = 0;
                    lb_firstData.Text = "Center";
                    lb_secondData.Text = "Radious";
                    break;
                default:
                    break;
            }
        }

        private void AddItem(object sender, EventArgs e)
        {
            DrawItem newItem = new DrawItem(comboBox1.SelectedItem.ToString(),
                new Vector2(pointAWidth.Value, pointAHeight.Value),
                new Vector2(pointBWidth.Value, pointBHeight.Value),
                colorDialog1.Color);
            drawList.Items.Add(newItem);

        }

        private void RemoveItem(object sender, EventArgs e)
        {
            if (drawList.SelectedIndex < 0)
                return;
            drawList.Items.RemoveAt(drawList.SelectedIndex);
        }

        private void colorPreview_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            colorPreview.BackColor = colorDialog1.Color;
        }

        private void drawList_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;

            g.FillRectangle(new SolidBrush(e.BackColor), e.Bounds);
            g.DrawString(drawList.Items[e.Index].ToString(), e.Font, new SolidBrush(((DrawItem)drawList.Items[e.Index]).color), new PointF(e.Bounds.X, e.Bounds.Y));

            e.DrawFocusRectangle();
        }

        private void DrawTheList(object sender, EventArgs e)
        {
            itemsToDraw.Clear();
            foreach (object item in drawList.Items)
            {
                itemsToDraw.Add((DrawItem)item);
            }
        }
    }
    struct DrawItem
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
    struct Vector2
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
    }
}
