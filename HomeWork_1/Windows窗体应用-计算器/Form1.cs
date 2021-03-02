using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                int result= int.Parse(textBox1.Text) + int.Parse(textBox2.Text);
                label2.Text = Convert.ToString(result);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                int result = int.Parse(textBox1.Text) - int.Parse(textBox2.Text);
                label2.Text = Convert.ToString(result);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                int result = int.Parse(textBox1.Text) * int.Parse(textBox2.Text);
                label2.Text = Convert.ToString(result);
            }
            else
            {
                int result = int.Parse(textBox1.Text) / int.Parse(textBox2.Text);
                label2.Text = Convert.ToString(result);
            }
        }
    }
}
