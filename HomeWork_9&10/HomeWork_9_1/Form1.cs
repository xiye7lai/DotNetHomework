using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork_9_1
{
    public partial class Form1 : Form
    {
        public BindingSource inforBindingSource;
        public bool crawling;
        public SimpleCrawler myCrawler;
        public Form1()
        {
            InitializeComponent();
            myCrawler = new SimpleCrawler();
            crawling = false;
            inforBindingSource = new BindingSource();
            dataGridView1.DataSource = inforBindingSource;
            dataGridView1.AutoResizeColumns();
            myCrawler.PageDownloaded += Crawler_PageDownloaded;
            myCrawler.CrawlerStopped += Crawler_CrawlerStopped;
        }

        private void Crawler_CrawlerStopped(SimpleCrawler obj)
        {
            Action action = () => { label1.Text = "爬虫已停止";  };
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
            
        }

        private void Crawler_PageDownloaded(SimpleCrawler crawler, string url, string info)
        {
            var pageInfo = new { Index = inforBindingSource.Count + 1, URL = url, Status = info };
            Action action = () => { inforBindingSource.Add(pageInfo); dataGridView1.AutoResizeColumns(); };
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            inforBindingSource.Clear();
            myCrawler.StartURL = textBox1.Text;

            Match match = Regex.Match(myCrawler.StartURL, SimpleCrawler.urlParseRegex);
            if (match.Length == 0) return;
            string host = match.Groups["host"].Value;
            myCrawler.HostFilter = "^" + host + "$";
            myCrawler.FileFilter = "((.html?|.aspx|.jsp|.php)$|^[^.]+$)";
            new Thread(myCrawler.Start).Start();
            label1.Text = "爬虫已启动....";
        }
    }
}
