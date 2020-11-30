using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Web_Crawler
{
    internal class Program
    {
        private static void Main()
        {
            Intosql sql = new Intosql();
            sql.Connection();
            Web_Crawler.Program Crawler = new Program();
            List<string> abc = new List<string> { "a", "b", "c" };
            try
            {                
                HtmlWeb webClient = new HtmlWeb();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                for(int i = 0; i < abc.Count(); i++)
                {
                    string loadurl = "https://www.basketball-reference.com/players/" + abc[i] + "/";
                    HtmlDocument loaddoc = webClient.Load(loadurl);
                    for(int j = 1; j < 2; j++)
                    {
                        string playerurl = Crawler.CrawlerPlayerurl(loaddoc , j);
                        if (playerurl != null)
                        {
                            HtmlDocument playerdoc = webClient.Load(playerurl);
                            Crawler.CrawlerPlayerinfo(playerdoc);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR=" + ex.ToString());
            }
            Console.ReadLine();
        }

        public string CrawlerPlayerurl(HtmlDocument doc , int membernum)
        {
            HtmlNodeCollection player = doc.DocumentNode.SelectNodes($"//*[@id='players']/tbody/tr[" + membernum + "]/th/a");
            if (player == null)
            {
                HtmlNodeCollection playerstr = doc.DocumentNode.SelectNodes($"//*[@id='players']/tbody/tr[" + membernum + "]/th/strong/a");
                string playerstrinfourl = "https://www.basketball-reference.com" + playerstr[0].Attributes["href"].Value;
                return playerstrinfourl;
            }
            else
            {
                string playerinfourl = "https://www.basketball-reference.com" + player[0].Attributes["href"].Value;
                return playerinfourl;
            }
        }

        public void CrawlerPlayerinfo (HtmlDocument doc)
        {
            HtmlNodeCollection name = doc.DocumentNode.SelectNodes($"//*[@id='meta']/div/h1/span");
            Console.WriteLine(name[0].InnerText.ToString());
            this.CrawlerPlayerCareer(doc,2,1);
        }

        public void CrawlerPlayerCareer(HtmlDocument doc , int i , int j)
        {
            HtmlNodeCollection careeritem = doc.DocumentNode.SelectNodes($"//*[@id='info']/div[4]/div[" + i + "]/div[" + j + "]/h4");
            HtmlNodeCollection careerdata = doc.DocumentNode.SelectNodes($"//*[@id='info']/div[4]/div[" + i + "]/div[" + j + "]/p[2]");
            List<string> playerinfo = new List<string>();
            if (careeritem != null)
            {
                j++;
                playerinfo.Add(careerdata[0].InnerText.ToString());
                Console.WriteLine(careeritem[0].InnerText.ToString() + " : " + careerdata[0].InnerText.ToString());
                this.CrawlerPlayerCareer(doc, i, j);
            }
            else if(careeritem == null && i < 5)
            {
                i++;
                j = 1;
                this.CrawlerPlayerCareer(doc, i, j);
            }
            foreach(var item in playerinfo)
            {
                Console.WriteLine(item);
            }
        }
    }
}