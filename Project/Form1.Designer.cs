
namespace MohakAoki
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.numeric_width = new System.Windows.Forms.NumericUpDown();
            this.numeric_height = new System.Windows.Forms.NumericUpDown();
            this.btnResize = new System.Windows.Forms.Button();
            this.pivot_X = new System.Windows.Forms.NumericUpDown();
            this.pivot_Y = new System.Windows.Forms.NumericUpDown();
            this.keepRatio = new System.Windows.Forms.CheckBox();
            this.liveChange = new System.Windows.Forms.CheckBox();
            this.btn_setPivot = new System.Windows.Forms.Button();
            this.lb_debug = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pointAWidth = new System.Windows.Forms.NumericUpDown();
            this.pointAHeight = new System.Windows.Forms.NumericUpDown();
            this.lb_firstData = new System.Windows.Forms.Label();
            this.pointBWidth = new System.Windows.Forms.NumericUpDown();
            this.pointBHeight = new System.Windows.Forms.NumericUpDown();
            this.lb_secondData = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnAnalyse = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorPreview = new System.Windows.Forms.Label();
            this.drawList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivot_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivot_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointAWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointAHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // numeric_width
            // 
            this.numeric_width.Location = new System.Drawing.Point(418, 41);
            this.numeric_width.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numeric_width.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numeric_width.Name = "numeric_width";
            this.numeric_width.Size = new System.Drawing.Size(120, 23);
            this.numeric_width.TabIndex = 1;
            this.numeric_width.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numeric_width.ValueChanged += new System.EventHandler(this.ResizePanel);
            // 
            // numeric_height
            // 
            this.numeric_height.Location = new System.Drawing.Point(544, 41);
            this.numeric_height.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numeric_height.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numeric_height.Name = "numeric_height";
            this.numeric_height.Size = new System.Drawing.Size(120, 23);
            this.numeric_height.TabIndex = 1;
            this.numeric_height.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numeric_height.ValueChanged += new System.EventHandler(this.ResizePanel);
            // 
            // btnResize
            // 
            this.btnResize.Location = new System.Drawing.Point(326, 419);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(86, 23);
            this.btnResize.TabIndex = 2;
            this.btnResize.Text = "Resize";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.ResizePanel);
            // 
            // pivot_X
            // 
            this.pivot_X.Location = new System.Drawing.Point(418, 70);
            this.pivot_X.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.pivot_X.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.pivot_X.Name = "pivot_X";
            this.pivot_X.Size = new System.Drawing.Size(120, 23);
            this.pivot_X.TabIndex = 1;
            this.pivot_X.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.pivot_X.ValueChanged += new System.EventHandler(this.ResizePanel);
            // 
            // pivot_Y
            // 
            this.pivot_Y.Location = new System.Drawing.Point(544, 70);
            this.pivot_Y.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.pivot_Y.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.pivot_Y.Name = "pivot_Y";
            this.pivot_Y.Size = new System.Drawing.Size(120, 23);
            this.pivot_Y.TabIndex = 1;
            this.pivot_Y.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.pivot_Y.ValueChanged += new System.EventHandler(this.ResizePanel);
            // 
            // keepRatio
            // 
            this.keepRatio.AutoSize = true;
            this.keepRatio.Checked = true;
            this.keepRatio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.keepRatio.Location = new System.Drawing.Point(13, 419);
            this.keepRatio.Name = "keepRatio";
            this.keepRatio.Size = new System.Drawing.Size(112, 19);
            this.keepRatio.TabIndex = 3;
            this.keepRatio.Text = "Keep Pivot Ratio";
            this.keepRatio.UseVisualStyleBackColor = true;
            this.keepRatio.CheckedChanged += new System.EventHandler(this.liveChange_CheckedChanged);
            // 
            // liveChange
            // 
            this.liveChange.AutoSize = true;
            this.liveChange.Location = new System.Drawing.Point(131, 419);
            this.liveChange.Name = "liveChange";
            this.liveChange.Size = new System.Drawing.Size(91, 19);
            this.liveChange.TabIndex = 3;
            this.liveChange.Text = "Live Change";
            this.liveChange.UseVisualStyleBackColor = true;
            this.liveChange.CheckedChanged += new System.EventHandler(this.liveChange_CheckedChanged);
            // 
            // btn_setPivot
            // 
            this.btn_setPivot.Location = new System.Drawing.Point(234, 419);
            this.btn_setPivot.Name = "btn_setPivot";
            this.btn_setPivot.Size = new System.Drawing.Size(86, 23);
            this.btn_setPivot.TabIndex = 2;
            this.btn_setPivot.Text = "Set Pivot";
            this.btn_setPivot.UseVisualStyleBackColor = true;
            this.btn_setPivot.Click += new System.EventHandler(this.SetPivot);
            // 
            // lb_debug
            // 
            this.lb_debug.AutoSize = true;
            this.lb_debug.Location = new System.Drawing.Point(419, 426);
            this.lb_debug.Name = "lb_debug";
            this.lb_debug.Size = new System.Drawing.Size(38, 15);
            this.lb_debug.TabIndex = 4;
            this.lb_debug.Text = "label1";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkRed;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(418, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 5);
            this.label1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(449, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Width/X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(574, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Height/Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(670, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Size";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(670, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Pivot";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Line DDA",
            "Line Bresenham",
            "Circle"});
            this.comboBox1.Location = new System.Drawing.Point(543, 123);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(670, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Type";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(417, 123);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(118, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.AddItem);
            // 
            // pointAWidth
            // 
            this.pointAWidth.Location = new System.Drawing.Point(418, 152);
            this.pointAWidth.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.pointAWidth.Minimum = new decimal(new int[] {
            800,
            0,
            0,
            -2147483648});
            this.pointAWidth.Name = "pointAWidth";
            this.pointAWidth.Size = new System.Drawing.Size(120, 23);
            this.pointAWidth.TabIndex = 1;
            this.pointAWidth.ValueChanged += new System.EventHandler(this.ResizePanel);
            // 
            // pointAHeight
            // 
            this.pointAHeight.Location = new System.Drawing.Point(544, 152);
            this.pointAHeight.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.pointAHeight.Minimum = new decimal(new int[] {
            800,
            0,
            0,
            -2147483648});
            this.pointAHeight.Name = "pointAHeight";
            this.pointAHeight.Size = new System.Drawing.Size(120, 23);
            this.pointAHeight.TabIndex = 1;
            this.pointAHeight.ValueChanged += new System.EventHandler(this.ResizePanel);
            // 
            // lb_firstData
            // 
            this.lb_firstData.AutoSize = true;
            this.lb_firstData.Location = new System.Drawing.Point(670, 154);
            this.lb_firstData.Name = "lb_firstData";
            this.lb_firstData.Size = new System.Drawing.Size(15, 15);
            this.lb_firstData.TabIndex = 4;
            this.lb_firstData.Text = "A";
            // 
            // pointBWidth
            // 
            this.pointBWidth.Location = new System.Drawing.Point(417, 181);
            this.pointBWidth.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.pointBWidth.Minimum = new decimal(new int[] {
            800,
            0,
            0,
            -2147483648});
            this.pointBWidth.Name = "pointBWidth";
            this.pointBWidth.Size = new System.Drawing.Size(120, 23);
            this.pointBWidth.TabIndex = 1;
            this.pointBWidth.ValueChanged += new System.EventHandler(this.ResizePanel);
            // 
            // pointBHeight
            // 
            this.pointBHeight.Location = new System.Drawing.Point(543, 181);
            this.pointBHeight.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.pointBHeight.Minimum = new decimal(new int[] {
            800,
            0,
            0,
            -2147483648});
            this.pointBHeight.Name = "pointBHeight";
            this.pointBHeight.Size = new System.Drawing.Size(120, 23);
            this.pointBHeight.TabIndex = 1;
            this.pointBHeight.ValueChanged += new System.EventHandler(this.ResizePanel);
            // 
            // lb_secondData
            // 
            this.lb_secondData.AutoSize = true;
            this.lb_secondData.Location = new System.Drawing.Point(671, 183);
            this.lb_secondData.Name = "lb_secondData";
            this.lb_secondData.Size = new System.Drawing.Size(14, 15);
            this.lb_secondData.TabIndex = 4;
            this.lb_secondData.Text = "B";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(417, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(314, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "The Folloing datas are based on pivot. not corner";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(419, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Draw List";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(417, 227);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(118, 23);
            this.btnDraw.TabIndex = 2;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.DrawTheList);
            // 
            // btnAnalyse
            // 
            this.btnAnalyse.Location = new System.Drawing.Point(546, 227);
            this.btnAnalyse.Name = "btnAnalyse";
            this.btnAnalyse.Size = new System.Drawing.Size(118, 23);
            this.btnAnalyse.TabIndex = 2;
            this.btnAnalyse.Text = "Analyse";
            this.btnAnalyse.UseVisualStyleBackColor = true;
            this.btnAnalyse.Click += new System.EventHandler(this.ResizePanel);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(670, 227);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.RemoveItem);
            // 
            // colorDialog1
            // 
            this.colorDialog1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            // 
            // colorPreview
            // 
            this.colorPreview.BackColor = System.Drawing.Color.Red;
            this.colorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPreview.ForeColor = System.Drawing.Color.White;
            this.colorPreview.Location = new System.Drawing.Point(644, 207);
            this.colorPreview.Name = "colorPreview";
            this.colorPreview.Size = new System.Drawing.Size(20, 17);
            this.colorPreview.TabIndex = 5;
            this.colorPreview.Click += new System.EventHandler(this.colorPreview_Click);
            // 
            // drawList
            // 
            this.drawList.BackColor = System.Drawing.SystemColors.MenuText;
            this.drawList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.drawList.FormattingEnabled = true;
            this.drawList.ItemHeight = 15;
            this.drawList.Location = new System.Drawing.Point(419, 273);
            this.drawList.Name = "drawList";
            this.drawList.Size = new System.Drawing.Size(329, 139);
            this.drawList.TabIndex = 7;
            this.drawList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.drawList_DrawItem);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 450);
            this.Controls.Add(this.drawList);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.colorPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_secondData);
            this.Controls.Add(this.lb_firstData);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lb_debug);
            this.Controls.Add(this.liveChange);
            this.Controls.Add(this.keepRatio);
            this.Controls.Add(this.btn_setPivot);
            this.Controls.Add(this.btnAnalyse);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnResize);
            this.Controls.Add(this.pointBHeight);
            this.Controls.Add(this.pointBWidth);
            this.Controls.Add(this.pointAHeight);
            this.Controls.Add(this.pointAWidth);
            this.Controls.Add(this.pivot_Y);
            this.Controls.Add(this.pivot_X);
            this.Controls.Add(this.numeric_height);
            this.Controls.Add(this.numeric_width);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivot_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivot_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointAWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointAHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown numeric_width;
        private System.Windows.Forms.NumericUpDown numeric_height;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.NumericUpDown pivot_X;
        private System.Windows.Forms.NumericUpDown pivot_Y;
        private System.Windows.Forms.CheckBox keepRatio;
        private System.Windows.Forms.CheckBox liveChange;
        private System.Windows.Forms.Button btn_setPivot;
        private System.Windows.Forms.Label lb_debug;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.NumericUpDown pointAWidth;
        private System.Windows.Forms.NumericUpDown pointAHeight;
        private System.Windows.Forms.Label lb_firstData;
        private System.Windows.Forms.NumericUpDown pointBWidth;
        private System.Windows.Forms.NumericUpDown pointBHeight;
        private System.Windows.Forms.Label lb_secondData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnAnalyse;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label colorPreview;
        private System.Windows.Forms.ListBox drawList;
    }
}

