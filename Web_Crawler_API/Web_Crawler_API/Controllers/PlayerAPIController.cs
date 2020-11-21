using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Crawler_API.Models;

namespace Web_Crawler_API.Controllers
{
    [RoutePrefix("api/[Controller]/[action]")]
    public class PlayerAPIController : ApiController
    {
        public List<PlayersModel> GetPlayers()
        {
        }
    }
}