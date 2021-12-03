using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MohakAoki
{
    public partial class TransformTable : Form
    {
        private Transform newTrans = new Transform();
        public Action<Transform> GiveResult;
        public TransformTable()
        {
            InitializeComponent();
        }
        public void SetBaseItem(DrawItem _item)
        {
            newTrans.baseItem = _item;
        }
        void UpdateList()
        {
            lboxTransforms.Items.Clear();
            foreach (Transform.Trans item in newTrans.transforms)
            {
                lboxTransforms.Items.Add(item);
            }
        }
        void AddToList(Transform.Trans _trans)
        {
            newTrans.transforms.Add(_trans);
            UpdateList();
        }
        void RemoveFromList(int _index)
        {
            newTrans.transforms.RemoveAt(_index);
            UpdateList();
        }
        void MoveUp(int _index)
        {
            if (_index > 0)
            {
                Transform.Trans temp = newTrans.transforms[_index];
                newTrans.transforms[_index] = newTrans.transforms[_index - 1];
                newTrans.transforms[_index - 1] = temp;
            }
            UpdateList();
        }
        void MoveDown(int _index)
        {
            if (_index < lboxTransforms.Items.Count - 1)
            {
                Transform.Trans temp = newTrans.transforms[_index];
                newTrans.transforms[_index] = newTrans.transforms[_index + 1];
                newTrans.transforms[_index + 1] = temp;
            }
            UpdateList();
        }
        private void btnAddPos_Click(object sender, EventArgs e)
        {
            Transform.Trans trans = new Transform.Trans
            {
                type = Transform.TransType.Pos,
                data = new Vector2(positionX.Value, positionY.Value)
            };
            Transform transform = new Transform();
            AddToList(trans);
        }

        private void btnAddSca_Click(object sender, EventArgs e)
        {
            Transform.Trans trans = new Transform.Trans
            {
                type = Transform.TransType.Sca,
                data = new Vector2(scaleX.Value, scaleY.Value)
            };
            Transform transform = new Transform();
            AddToList(trans);
        }

        private void btnAddRot_Click(object sender, EventArgs e)
        {
            Transform.Trans trans = new Transform.Trans
            {
                type = Transform.TransType.Rot,
                data = new Vector2(degree.Value, 0)
            };
            Transform transform = new Transform();
            AddToList(trans);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lboxTransforms.SelectedIndex < 0)
            {
                MessageBox.Show("select and item then try delete again", "Not any item selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                RemoveFromList(lboxTransforms.SelectedIndex);
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (lboxTransforms.SelectedIndex < 0)
            {
                MessageBox.Show("select and item then try delete again", "Not any item selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MoveUp(lboxTransforms.SelectedIndex);
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (lboxTransforms.SelectedIndex < 0)
            {
                MessageBox.Show("select and item then try delete again", "Not any item selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MoveDown(lboxTransforms.SelectedIndex);
            }
        }

        private void lboxTransforms_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;

            g.FillRectangle(new SolidBrush(e.BackColor), e.Bounds);
            string text = string.Format("{0}. {1}", (e.Index + 1).ToString(), lboxTransforms.Items[e.Index].ToString());
            g.DrawString(text, e.Font, new SolidBrush(lboxTransforms.ForeColor), new PointF(e.Bounds.X, e.Bounds.Y));

            e.DrawFocusRectangle();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            GiveResult.Invoke(newTrans);
            Close();
        }
    }
}
