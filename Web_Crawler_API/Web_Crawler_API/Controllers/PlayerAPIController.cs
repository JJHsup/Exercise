using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Crawler_API.Models;
using Web_Crawler_API.Service;
using Web_Crawler_API.Repository;

namespace Web_Crawler_API.Controllers
{
    [RoutePrefix("api/[Controller]/[action]")]
    public class PlayerAPIController : ApiController
    {
        public string GetPlayers()
        {
            GetPlayerService service = new GetPlayerService();
            string result = service.Crawler();
            return result;
        }
    }
}