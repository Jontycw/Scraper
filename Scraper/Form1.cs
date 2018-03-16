using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Net.Http;

namespace Scraper
{
    public partial class Scraper : Form
    {
        public Timer timer;

        public static string[] Urls = LoadUrls();

        public Scraper()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            SetupUrlTextArea(Urls);
            await InitialLoopUrl(Urls);
        }

        public void InitTimer()
        {
            timer = new Timer();
            timer.Tick += new EventHandler(RunBtn_Click);
            timer.Interval = 10000;
            timer.Start();
        }

        public static string[] LoadUrls()
        {
            string[] Urls = File.ReadAllLines("input.txt");
            return Urls;
        }

        public void SetupUrlTextArea(string[] Urls)
        {
            foreach (string url in Urls)
            {
                taUrls.Text += url + "\r\n";
            }
        }

        public async Task loopUrl(string[] Urls)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.162 Safari/537.36");

            foreach (string url in Urls)
            {
                var html = await client.GetStringAsync(url);
                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(html);

                HtmlNode productDataNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='product-data left']/div[1]/div[1]");
                string title = productDataNode.SelectSingleNode("//h1").InnerText.Trim();

                HtmlNode amountNode = productDataNode.SelectSingleNode("//span[@class='amount']");
                if (amountNode == null)
                    amountNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@id='buybox']").SelectSingleNode("//span[@class='amount']");
                string trimmed = amountNode.InnerText.Replace(",", "");
                double price = double.Parse(trimmed);
                taMonitoredOutput.Text = "Date: " + DateTime.Now + "\r\n" + title + "\r\nR " + price + "";
                // File.AppendAllText("output.txt", $"{DateTime.Now} : {title} R{price}");  
            }
        }

        public async Task InitialLoopUrl(string[] Urls)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.162 Safari/537.36");

            foreach (string url in Urls)
            {
                var html = await client.GetStringAsync(url);
                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(html);

                HtmlNode productDataNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='product-data left']/div[1]/div[1]");
                string title = productDataNode.SelectSingleNode("//h1").InnerText.Trim();

                HtmlNode amountNode = productDataNode.SelectSingleNode("//span[@class='amount']");
                if (amountNode == null)
                    amountNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@id='buybox']").SelectSingleNode("//span[@class='amount']");
                string trimmed = amountNode.InnerText.Replace(",", "");
                double price = double.Parse(trimmed);
                taInitialOutput.Text += "Date: " + DateTime.Now + "\r\n" + title + "\r\nR " + price + "\r\n\r\n";
                // File.AppendAllText("output.txt", $"{DateTime.Now} : {title} R{price}");  
            }
        }

        private async void RunBtn_Click(object sender, EventArgs e)
        {
            InitTimer();
            await loopUrl(Urls);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            File.AppendAllText("input.txt", txtUrl.Text + "\r\n");
            txtUrl.Clear();
            LoadUrls();
        }
    }
}
