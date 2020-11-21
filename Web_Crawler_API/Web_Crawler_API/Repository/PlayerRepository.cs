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

        public void PlayerPost(PlayersModel players)
        {
            PlayersModel player = new PlayersModel()
            {
                PlayerName = players.PlayerName,
                G = players.G,
                PTS = players.PTS,
                TRB = players.TRB,
                AST = players.AST,
                FG = players.FG,
                FG3 = players.FG3,
                FT = players.FT,
                eFG = players.eFG,
                PER = players.PER,
                WS = players.WS
            };
            db.PlayersModels.Add(player);
            db.SaveChanges();
        }
    }
}