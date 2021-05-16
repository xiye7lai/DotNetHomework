using System;
using System.Collections;
using System.Collections.Concurrent;
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

    //参照老师提供代码进行优化修改
    public class SimpleCrawler
    {
        //信息的刷新输出
        public string Infor{ get; set; }
        //爬取结束事件
        public event Action<SimpleCrawler> CrawlerStopped;
        private ConcurrentDictionary<string, bool> urls = new ConcurrentDictionary<string, bool>();
        public Dictionary<string, bool> DownloadedPages { get; } = new Dictionary<string, bool>();
        //下载结束事件
        public event Action<SimpleCrawler,int, string, string> PageDownloaded;
        //待下载队列
        private ConcurrentQueue<string> queues = new ConcurrentQueue<string>();
        //URL检测表达式，用于在HTML文本中查找URL
        public static readonly string UrlDetectRegex = @"(href|HREF)[]*=[]*[""'](?<url>[^""'#>]+)[""']";
        //URL解析表达式
        public static readonly string urlParseRegex = @"^(?<site>(?<protocal>https?)://(?<host>[\w.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#?]*)";
        public string HostFilter { get; set; }
        public string FileFilter { get; set; }
        public int MaxPage { get; set; }
        public string StartURL { get; set; }
        public Encoding HtmlEncoding { get; set; }
        public SimpleCrawler()
        {
            Infor = "";
            MaxPage = 100;
            HtmlEncoding = Encoding.UTF8;
            HostFilter = "";
            FileFilter = "";
        }
        public void Start()
        {
            urls.Clear();
            queues = new ConcurrentQueue<string>();
            queues.Enqueue(StartURL);
            //建立task池
            List<Task> tasks = new List<Task>();
            int completedCount = 0;
            PageDownloaded += (crawler, index, url, info) => { completedCount++; };
            while (tasks.Count <=MaxPage)
            {
                if (queues.TryDequeue(out string url)!=true)
                {
                    if (completedCount < tasks.Count)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                Task t = Task.Run(() => DownloadAndParse(url,tasks.Count));
                tasks.Add(t);
            }
            Task.WaitAll(tasks.ToArray());
            CrawlerStopped(this);
        }
        private void DownloadAndParse(string url, int num)
        {
            Parse(DownLoad(url, num), url);
            urls[url] = true;
            PageDownloaded(this, num, url, "success");
        }
        private string DownLoad(string url, int num)
        {
            WebClient webClient = new WebClient();
            string s = webClient.DownloadString(url);
            webClient.Encoding = HtmlEncoding;
            File.WriteAllText(num + ".html",s, Encoding.UTF8);
            return s;
        }
        private void Parse(string html, string url)
        {
            var matches = new Regex(UrlDetectRegex).Matches(html);
            foreach (Match match in matches)
            {
                string linkUrl = match.Groups["url"].Value;
                if (linkUrl == null || linkUrl == "" || linkUrl.StartsWith("javascript:")) continue;
                linkUrl = FixUrl(linkUrl, url);
                Match linkUrlMatch = Regex.Match(linkUrl, urlParseRegex);
                string host = linkUrlMatch.Groups["host"].Value;
                string file = linkUrlMatch.Groups["file"].Value;
                if (file == "") file = "index.html";
                if (Regex.IsMatch(host, HostFilter) && Regex.IsMatch(file, FileFilter)
                  && !urls.ContainsKey(linkUrl))
                {
                    queues.Enqueue(linkUrl);
                    urls.TryAdd(linkUrl, false);
                }
            }
        }
        static private string FixUrl(string url, string pageUrl)
        {
            if (url.Contains("://"))
            {
                return url;
            }
            if (url.StartsWith("//"))
            {
                Match urlMatch = Regex.Match(pageUrl, urlParseRegex);
                string protocal = urlMatch.Groups["protocal"].Value;
                return protocal + ":" + url;
            }
            if (url.StartsWith("/"))
            {
                Match urlMatch = Regex.Match(pageUrl, urlParseRegex);
                String site = urlMatch.Groups["site"].Value;
                return site.EndsWith("/") ? site + url.Substring(1) : site + url;
            }

            if (url.StartsWith("../"))
            {
                url = url.Substring(3);
                int idx = pageUrl.LastIndexOf('/');
                return FixUrl(url, pageUrl.Substring(0, idx));
            }

            if (url.StartsWith("./"))
            {
                return FixUrl(url.Substring(2), pageUrl);
            }
            int end = pageUrl.LastIndexOf("/");
            return pageUrl.Substring(0, end) + "/" + url;
        }

    }
}
