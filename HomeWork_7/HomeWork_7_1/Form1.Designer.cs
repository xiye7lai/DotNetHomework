
namespace HomeWork_7_1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(115, 5);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(73, 25);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "递归深度";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown2.Location = new System.Drawing.Point(115, 62);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(73, 25);
            this.numericUpDown2.TabIndex = 3;
            this.numericUpDown2.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "主干长度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "右分支长度比";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.DecimalPlaces = 1;
            this.numericUpDown3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown3.Location = new System.Drawing.Point(115, 112);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(73, 25);
            this.numericUpDown3.TabIndex = 6;
            this.numericUpDown3.Value = new decimal(new int[] {
            6,
            0,
            0,
            65536});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "左分支长度比";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.DecimalPlaces = 1;
            this.numericUpDown4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown4.Location = new System.Drawing.Point(115, 164);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(73, 25);
            this.numericUpDown4.TabIndex = 8;
            this.numericUpDown4.Value = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            this.numericUpDown4.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "右分支角度";
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown5.Location = new System.Drawing.Point(115, 211);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDown5.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(73, 25);
            this.numericUpDown5.TabIndex = 10;
            this.numericUpDown5.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown5.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "左分支角度";
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown6.Location = new System.Drawing.Point(117, 266);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDown6.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(71, 25);
            this.numericUpDown6.TabIndex = 12;
            this.numericUpDown6.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown6.ValueChanged += new System.EventHandler(this.numericUpDown6_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 321);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "画笔颜色";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Items.AddRange(new object[] {
            "黑色",
            "蓝色",
            "红色",
            "绿色",
            "橙色"});
            this.listBox1.Location = new System.Drawing.Point(115, 321);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(45, 79);
            this.listBox1.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.numericUpDown6);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.numericUpDown5);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.numericUpDown4);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.numericUpDown3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numericUpDown2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 451);
            this.panel1.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(498, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(215, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(586, 450);
            this.panel2.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
    }
}

