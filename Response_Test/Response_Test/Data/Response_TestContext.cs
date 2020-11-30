using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Response_Test.Data
{
    public class Response_TestContext : DbContext
    {
       
    
        public Response_TestContext() : base("name=Response_TestContext")
        {
        }

        public System.Data.Entity.DbSet<Response_Test.Models.TesterInfomationModel> TesterInfomationModels { get; set; }
    }
}
