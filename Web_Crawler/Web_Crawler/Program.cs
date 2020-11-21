using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Web_Crawler
{
    public class Ht
    {
        public HtmlNodeCollection HtmlList(int i, HtmlDocument doc)
        {
            HtmlNodeCollection item = doc.DocumentNode.SelectNodes($"//*[@id='div_alphabet']/ul/li[" + i + "]");
            return item;
        }
    }

    internal class Program
    {
        private static void Main()
        {
            Ht a = new Ht();
            try
            {
                HtmlWeb webClient = new HtmlWeb(); //建立htmlweb
                //處理C# 連線 HTTPS 網站發生驗證失敗導致基礎連接已關閉
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                HtmlDocument doc = webClient.Load("https://www.basketball-reference.com/players/"); //載入網址資料
                for (var i = 1; i < 27; i++)
                {
                    HtmlNodeCollection list = a.HtmlList(i, doc);
                    string ans = list[0].InnerText.ToString();
                    string url = "https://www.basketball-reference.com" + list[0].Attributes["href"].Value;
                    Console.WriteLine(ans);
                    Console.WriteLine(url);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR=" + ex.ToString());
            }
            Console.ReadLine();
        }
    }
}