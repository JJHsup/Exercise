using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Response_Test.Models;
using Response_Test.Repository;

namespace Response_Test.Controllers
{
    public class TestPageController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Home(TesterInfomationModel tester)
        {
            TesterBuildRepository build = new TesterBuildRepository();
            build.BuildTester(tester);
            return View();
        }
    }
}