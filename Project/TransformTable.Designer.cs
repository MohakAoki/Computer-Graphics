
namespace MohakAoki
{
    partial class TransformTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddPos = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnAddSca = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.positionX = new System.Windows.Forms.NumericUpDown();
            this.positionY = new System.Windows.Forms.NumericUpDown();
            this.scaleX = new System.Windows.Forms.NumericUpDown();
            this.scaleY = new System.Windows.Forms.NumericUpDown();
            this.degree = new System.Windows.Forms.NumericUpDown();
            this.lboxTransforms = new System.Windows.Forms.ListBox();
            this.btnAddRot = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.positionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.degree)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddPos
            // 
            this.btnAddPos.Location = new System.Drawing.Point(372, 12);
            this.btnAddPos.Name = "btnAddPos";
            this.btnAddPos.Size = new System.Drawing.Size(117, 23);
            this.btnAddPos.TabIndex = 0;
            this.btnAddPos.Text = "Add Position";
            this.btnAddPos.UseVisualStyleBackColor = true;
            this.btnAddPos.Click += new System.EventHandler(this.btnAddPos_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(372, 232);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(117, 23);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnAddSca
            // 
            this.btnAddSca.Location = new System.Drawing.Point(372, 41);
            this.btnAddSca.Name = "btnAddSca";
            this.btnAddSca.Size = new System.Drawing.Size(117, 23);
            this.btnAddSca.TabIndex = 0;
            this.btnAddSca.Text = "Add Scale";
            this.btnAddSca.UseVisualStyleBackColor = true;
            this.btnAddSca.Click += new System.EventHandler(this.btnAddSca_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Degree";
            // 
            // positionX
            // 
            this.positionX.Location = new System.Drawing.Point(13, 12);
            this.positionX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.positionX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.positionX.Name = "positionX";
            this.positionX.Size = new System.Drawing.Size(127, 23);
            this.positionX.TabIndex = 3;
            // 
            // positionY
            // 
            this.positionY.Location = new System.Drawing.Point(195, 12);
            this.positionY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.positionY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.positionY.Name = "positionY";
            this.positionY.Size = new System.Drawing.Size(127, 23);
            this.positionY.TabIndex = 3;
            // 
            // scaleX
            // 
            this.scaleX.Location = new System.Drawing.Point(13, 42);
            this.scaleX.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.scaleX.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.scaleX.Name = "scaleX";
            this.scaleX.Size = new System.Drawing.Size(127, 23);
            this.scaleX.TabIndex = 3;
            // 
            // scaleY
            // 
            this.scaleY.Location = new System.Drawing.Point(195, 42);
            this.scaleY.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.scaleY.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.scaleY.Name = "scaleY";
            this.scaleY.Size = new System.Drawing.Size(127, 23);
            this.scaleY.TabIndex = 3;
            // 
            // degree
            // 
            this.degree.Location = new System.Drawing.Point(13, 70);
            this.degree.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.degree.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.degree.Name = "degree";
            this.degree.Size = new System.Drawing.Size(309, 23);
            this.degree.TabIndex = 3;
            // 
            // lboxTransforms
            // 
            this.lboxTransforms.BackColor = System.Drawing.Color.Black;
            this.lboxTransforms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lboxTransforms.ForeColor = System.Drawing.Color.White;
            this.lboxTransforms.FormattingEnabled = true;
            this.lboxTransforms.ItemHeight = 15;
            this.lboxTransforms.Location = new System.Drawing.Point(13, 100);
            this.lboxTransforms.Name = "lboxTransforms";
            this.lboxTransforms.Size = new System.Drawing.Size(476, 124);
            this.lboxTransforms.TabIndex = 4;
            this.lboxTransforms.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lboxTransforms_DrawItem);
            // 
            // btnAddRot
            // 
            this.btnAddRot.Location = new System.Drawing.Point(372, 70);
            this.btnAddRot.Name = "btnAddRot";
            this.btnAddRot.Size = new System.Drawing.Size(117, 23);
            this.btnAddRot.TabIndex = 0;
            this.btnAddRot.Text = "Add Rotation";
            this.btnAddRot.UseVisualStyleBackColor = true;
            this.btnAddRot.Click += new System.EventHandler(this.btnAddRot_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(249, 232);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(117, 23);
            this.btnCancle.TabIndex = 0;
            this.btnCancle.Text = "Cancle";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(126, 232);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(66, 232);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(45, 23);
            this.btnMoveUp.TabIndex = 0;
            this.btnMoveUp.Text = "/\\";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(15, 232);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(45, 23);
            this.btnMoveDown.TabIndex = 0;
            this.btnMoveDown.Text = "\\/";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // TransformTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 267);
            this.Controls.Add(this.lboxTransforms);
            this.Controls.Add(this.degree);
            this.Controls.Add(this.scaleY);
            this.Controls.Add(this.scaleX);
            this.Controls.Add(this.positionY);
            this.Controls.Add(this.positionX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddSca);
            this.Controls.Add(this.btnAddRot);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnAddPos);
            this.Name = "TransformTable";
            this.Text = "TransformTable";
            ((System.ComponentModel.ISupportInitialize)(this.positionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.degree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddPos;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnAddSca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown positionX;
        private System.Windows.Forms.NumericUpDown positionY;
        private System.Windows.Forms.NumericUpDown scaleX;
        private System.Windows.Forms.NumericUpDown scaleY;
        private System.Windows.Forms.NumericUpDown degree;
        private System.Windows.Forms.ListBox lboxTransforms;
        private System.Windows.Forms.Button btnAddRot;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
    }
}