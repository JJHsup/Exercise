using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Web_Crawler_API.Models;

namespace Web_Crawler_API.Service
{
    public class GetPlayerFormWeb
    {
        public HtmlNodeCollection HtmlNodesIndex(int member, HtmlDocument doc)
        {
            HtmlNodeCollection item = doc.DocumentNode.SelectNodes($"//*[@id='div_alphabet']/ul/li[" + member + "]/th/a");
            return item;
        }

        public List<string> Index()
        {
            List<string> ABCIndex = new List<string>();
            string url = "https://www.basketball-reference.com/players/";
            try
            {
                HtmlWeb webClient = new HtmlWeb();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                HtmlDocument doc = webClient.Load(url);
                for (int i = 1; i < 27; i++)
                {
                    HtmlNodeCollection list = HtmlNodesIndex(i, doc);
                    ABCIndex.Add("https://www.basketball-reference.com" + list[0].Attributes["href"].Value);
                }

                return ABCIndex;
            }
            catch (Exception ex)
            {
                ABCIndex.Add(ex.ToString());
                return ABCIndex;
            }
        }

        public List<PlayersModel> players()
        {
            try
            {
                HtmlWeb webClient = new HtmlWeb();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                HtmlDocument doc = webClient.Load("https://www.basketball-reference.com/players/b/"); //載入網址資料
                HtmlNodeCollection list = doc.DocumentNode.SelectNodes($"//*[@id='players']/tbody/tr[1]/th/a"); //抓取Xpath資料
                string ans = list[0].InnerText.ToString();
                string url = "https://www.basketball-reference.com/" + list[0].Attributes["href"].Value;
                Console.WriteLine(ans);
                Console.WriteLine(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR=" + ex.ToString());
            }
            Console.ReadLine();
        }
    }
}