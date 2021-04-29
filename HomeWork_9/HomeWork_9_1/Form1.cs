using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork_9_1
{
    public partial class Form1 : Form
    {
        public SimpleCrawler myCrawler;
        public Thread thread;
        bool crawling;
        public Form1()
        {
            InitializeComponent();
            myCrawler = new SimpleCrawler();
            crawling = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crawling = true;
            thread = new Thread(myCrawler.Crawl);
            thread.Start(textBox1.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            richTextBox1.Text = myCrawler.Infor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "暂停爬取")
            {
                crawling = false;
                thread.Suspend();
                button2.Text = "继续爬取";
            }
            else if (button2.Text == "继续爬取")
            {
                crawling = true;
                thread.Resume();
                button2.Text = "暂停爬取";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            thread.Abort();
        }
    }
}
