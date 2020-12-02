using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Response_Test.Controllers.API
{
    [RoutePrefix("api/[Controller]/[action]")]
    public class TestOneController : ApiController
    {
        [HttpGet]
        public List<string> TestOne()
        {
            List<string> result = new List<string>();
            return result;
        }
    }
}