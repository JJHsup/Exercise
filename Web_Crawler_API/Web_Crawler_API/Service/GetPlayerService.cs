using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Web_Crawler_API.Models;
using Web_Crawler_API.Repository;

namespace Web_Crawler_API.Service
{
    public class GetPlayerService
    {
        public string Crawler()
        {
            Web_Crawler_API.Service.GetPlayerService  Crawler = new GetPlayerService();
            List<string> abc = new List<string> { "a", "b", "c" };
            List<string> ans = new List<string>();
            try
            {
                HtmlWeb webClient = new HtmlWeb();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                //for (int i = 0; i < abc.Count(); i++)
                //{
                    string loadurl = "https://www.basketball-reference.com/players/" + "a" + "/";
                    HtmlDocument loaddoc = webClient.Load(loadurl);
                    for (int j = 1; j < 9999; j++)
                    {
                        string playerurl = Crawler.CrawlerPlayerurl(loaddoc, j);
                        if (playerurl != null)
                        {
                            HtmlDocument playerdoc = webClient.Load(playerurl);
                            ans = Crawler.CrawlerPlayerinfo(playerdoc);
                            PlayerRepository player = new PlayerRepository();
                            player.PlayerPost(ans);
                        }
                        else
                        {
                            break;
                        }
                        ans.Clear();
                    }
                //}
                return "true";
            }
            catch (Exception ex)
            {
                string exc = ex.ToString();
                return exc;
            }
        }

        public string CrawlerPlayerurl(HtmlDocument doc, int membernum)
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

        public List<string> CrawlerPlayerinfo(HtmlDocument doc)
        {
            List<string> member = new List<string>();
            HtmlNodeCollection name = doc.DocumentNode.SelectNodes($"//*[@id='meta']/div/h1/span");
            this.CrawlerPlayerCareer(doc, 2, 1, name[0].InnerText.ToString());
            foreach (var item in player)
            {
                member.Add(item);
            }
            member.Add(name[0].InnerText.ToString());
            this.player.Clear();
            return member;
        }

        readonly List<string> player = new List<string>();

        public void CrawlerPlayerCareer(HtmlDocument doc, int i, int j , string name)
        {
            HtmlNodeCollection careeritem = doc.DocumentNode.SelectNodes($"//*[@id='info']/div[4]/div[" + i + "]/div[" + j + "]/h4");
            HtmlNodeCollection careerdata = doc.DocumentNode.SelectNodes($"//*[@id='info']/div[4]/div[" + i + "]/div[" + j + "]/p[2]");
            
            if (careeritem != null)
            {
                j++;
                player.Add(careerdata[0].InnerText.ToString());
                this.CrawlerPlayerCareer(doc, i, j , name);
            }
            else if (careeritem == null && i < 5)
            {
                i++;
                j = 1;
                this.CrawlerPlayerCareer(doc, i, j, name);
            }
        }
    }
    
}