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
    public partial class Form1 : Form
    {
        public Timer timer;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void InitTimer()
        {
            timer = new Timer();
            timer.Tick += new EventHandler(RunBtn_Click);
            timer.Interval = 1000;
            timer.Start();
        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            try
            {
                InitTimer();
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.162 Safari/537.36");

                //using (StreamReader sr = new StreamReader("input.txt"))
                //{
                //    while (!sr.EndOfStream)
                //    {
                //        var html = client.GetStringAsync(sr.ReadLine()).Result;
                var html = client.GetStringAsync(UrlTbx.Text).Result;
                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(html);

                HtmlNode productDataNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='product-data left']/div[1]/div[1]");
                string title = productDataNode.SelectSingleNode("//h1").InnerText.Trim();

                HtmlNode amountNode = productDataNode.SelectSingleNode("//span[@class='amount']");
                if (amountNode == null)
                    amountNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@id='buybox']").SelectSingleNode("//span[@class='amount']");
                string trimmed = amountNode.InnerText.Replace(",", "");
                double price = double.Parse(trimmed);
                OutputTa.Text = "Date: " + DateTime.Now + "\r\n" + title + "\r\nR " + price + "";
               // File.AppendAllText("output.txt", $"{DateTime.Now} : {title} R{price}");
                //    }
                //}
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
