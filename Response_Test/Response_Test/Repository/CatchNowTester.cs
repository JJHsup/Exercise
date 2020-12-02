using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Response_Test.Data;

namespace Response_Test.Repository
{
    public class CatchNowTester
    {
        private readonly Response_TestContext db = new Response_TestContext();
        public string Name()
        {
            string result = db.TesterInfomationModels.OrderBy(x => x.Login).FirstOrDefault().TesterName;
            return result;
        }
    }
}