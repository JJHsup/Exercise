using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Response_Test.Models;
using Response_Test.Data;

namespace Response_Test.Repository
{
    public class TesterBuildRepository
    {
        private readonly Response_TestContext db = new Response_TestContext();

        public void BuildTester(TesterInfomationModel tester)
        {
            TesterInfomationModel result = new TesterInfomationModel
            {
                TesterName = tester.TesterName,
                Login = DateTime.Now
            };
            db.TesterInfomationModels.Add(result);
            db.SaveChanges();
        }
    }
}