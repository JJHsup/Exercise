using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Crawler_API.Data;
using Web_Crawler_API.Models;

namespace Web_Crawler_API.Repository
{
    public class PlayerRepository
    {
        private readonly Web_Crawler_APIContext db = new Web_Crawler_APIContext();

        public void PlayerPost(List<string> players)
        {
            PlayersModel player = new PlayersModel()
            {
                Name = players[10],
                G = players[9],
                PTS = players[8],
                TRB = players[7],
                AST = players[6],
                FG = players[5],
                FG3 = players[4],
                FT = players[3],
                eFG = players[2],
                PER = players[1],
                WS = players[0]
            };
            db.APlayer.Add(player);
            db.SaveChanges();
        }
    }
}