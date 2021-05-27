using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
namespace Lab4_PhanVanTiep_19522347_
{
    public partial class Bt4 : Form
    {
        public Bt4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Source f = new Source(textBox1.Text);
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DownloadImagesFromUrl("http://www.onlinetrade.ru/catalogue/televizori-c181/", @"C:\Users\Admin\Downloads\image");
        }

        public void DownloadImagesFromUrl(string url, string folderImagesPath)
        {
            var uri = new Uri(url + "/?per_page=50");
            var pages = new List<HtmlNode> { LoadHtmlDocument(uri) };

            pages.AddRange(LoadOtherPages(pages[0], url));

            pages.SelectMany(p => p.SelectNodes("//a[@class='catalog__displayedItem__columnFotomainLnk']/img"))
                 .Select(node => Tuple.Create(new UriBuilder(uri.Scheme, uri.Host, uri.Port, node.Attributes["src"].Value).Uri, new WebClient()))
                 .AsParallel()
                 .ForAll(t => DownloadImage(folderImagesPath, t.Item1, t.Item2));
        }

        private static void DownloadImage(string folderImagesPath, Uri url, WebClient webClient)
        {
            try
            {
                webClient.DownloadFile(url, Path.Combine(folderImagesPath, Path.GetFileName(url.ToString())));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static IEnumerable<HtmlNode> LoadOtherPages(HtmlNode firstPage, string url)
        {
            return Enumerable.Range(1, DiscoverTotalPages(firstPage))
                             .AsParallel()
                             .Select(i => LoadHtmlDocument(new Uri(url + "/?per_page=50&page=" + i)));
        }

        private static int DiscoverTotalPages(HtmlNode documentNode)
        {
            var totalItemsDescription = documentNode.SelectNodes("//div[@class='catalogItemList__numsInWiev']").First().InnerText.Trim();
            var totalItems = int.Parse(Regex.Match(totalItemsDescription, @"\d+$").ToString());
            var totalPages = (int)Math.Ceiling(totalItems / 50d);
            return totalPages;
        }

        private static HtmlNode LoadHtmlDocument(Uri uri)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            var wc = new WebClient();
            doc.LoadHtml(wc.DownloadString(uri));
            var documentNode = doc.DocumentNode;
            return documentNode;
        }
    }
}
