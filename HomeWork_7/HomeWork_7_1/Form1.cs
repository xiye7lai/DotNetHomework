using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork_7_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
     
        private Graphics graphics;

        Dictionary<int, Pen> pairs = new Dictionary<int, Pen>()
        {{0,Pens.Black },{ 1,Pens.Blue} ,{ 2,Pens.Red},{ 3,Pens.Green},{4,Pens.Orange } };

        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;

        void DrawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            
            DrawLine(x0, y0, x1, y1);
            
            DrawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            DrawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
            
        }

        private void DrawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(pairs[listBox1.SelectedIndex], (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            per1 = (double)numericUpDown3.Value;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            per2 = (double)numericUpDown4.Value;
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            th1 = ((int)numericUpDown5.Value) * Math.PI / 180;
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            th2 = ((int)numericUpDown6.Value) * Math.PI / 180;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = panel2.CreateGraphics();
            graphics.Clear(BackColor);
            DrawCayleyTree((int)numericUpDown1.Value, 200, 310, (double)numericUpDown2.Value, -Math.PI / 2);
        }
    }
}
