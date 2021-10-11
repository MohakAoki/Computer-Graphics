using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MohakAoki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Initialize()
        {
            int Width = (int)numeric_width.Value;
            int Height = (int)numeric_height.Value;
            int X = (int)pivot_X.Value;
            int Y = (int)pivot_Y.Value;
            Renderer.Initialize(X, Y, Width, Height);
            comboBox1.SelectedIndex = 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Initialize();
            UpdatePreview();
        }
        private void UpdatePreview()
        {
            pictureBox1.Image = null;
            pictureBox1.Image = Renderer.GetRender();
        }
        private void ResizePanel(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(Button) && !liveChange.Checked)
                return;

            if (!liveChange.Checked)
            {
                Renderer.CalculateRatio();
            }
            //MessageBox.Show(string.Format("Size: {0} \nPivot: {1}\nratio: {2}", size, pivot, ratio));
            int Width = (int)numeric_width.Value;
            int Height = (int)numeric_height.Value;
            Renderer.SetSize(Width, Height);

            if (keepRatio.Checked)
            {
                pivot_X.Value = (int)MathF.Round(Renderer.size.Width * Renderer.ratio.X);
            }
            if (keepRatio.Checked)
            {
                pivot_Y.Value = (int)MathF.Round(Renderer.size.Height * Renderer.ratio.Y);
            }
            int X = (int)pivot_X.Value;
            int Y = (int)pivot_Y.Value;
            Renderer.SetPivot(X, Y);
            UpdatePreview();
        }

        private void liveChange_CheckedChanged(object sender, EventArgs e)
        {
            btnResize.Enabled = !liveChange.Checked;
            btn_setPivot.Enabled = !liveChange.Checked;
            btnDraw.Enabled = !liveChange.Checked;
            Renderer.CalculateRatio();
            if (liveChange.Checked)
                UpdatePreview();
        }

        private void SetPivot(object sender, EventArgs e)
        {
            int X = (int)pivot_X.Value;
            int Y = (int)pivot_Y.Value;
            Renderer.SetPivot(X, Y);
            UpdatePreview();
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
            UpdatePreview();
        }

        private void RemoveItem(object sender, EventArgs e)
        {
            if (drawList.SelectedIndex < 0)
                return;
            drawList.Items.RemoveAt(drawList.SelectedIndex);
            DrawTheList(sender, e);
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
            DrawItem[] _items = new DrawItem[drawList.Items.Count];
            for (int i = 0; i < drawList.Items.Count; i++)
            {
                _items[i] = (DrawItem)(drawList.Items[i]);
            }
            Renderer.AddItemsToDraw(_items, false);
            UpdatePreview();
        }
    }    
}
