using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web_Crawler_API.Data
{
    public class Web_Crawler_APIContext : DbContext
    {
        public Web_Crawler_APIContext() : base("name=Web_Crawler_APIContext")
        {
        }

        public System.Data.Entity.DbSet<Web_Crawler_API.Models.PlayersModel> PlayersModels { get; set; }
    }
}