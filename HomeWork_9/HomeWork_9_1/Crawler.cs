using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork_9_1
{
    public class SimpleCrawler
    {
        public string Infor{ get; set; }
        private Hashtable urls = new Hashtable();
        private int count = 0;
        /*static void Main(string[] args)
        {
            SimpleCrawler myCrawler = new SimpleCrawler();
            //if (args.Length >= 1) startUrl = args[0];
            new Thread(myCrawler.Crawl).Start("http://www.cnblogs.com/dstang2000/");
        }*/
        public SimpleCrawler()
        {
            Infor = "结果如下：\n";
        }
        public void Crawl(object object1)
        {
            this.urls.Add(object1.ToString(), false);
            Infor += "开始爬行了.... \n";
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }

                if (current == null || count > 10) break;
                Infor += "爬行" + current + "页面!\n";
                string html = DownLoad(current); // 下载
                urls[current] = true;
                count++;
                Parse(html);//解析,并加入新的链接
                Infor += "爬行结束\n";
            }
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        private void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
        
    }
}
