using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Response_Test.Models
{
    public class TesterInfomationModel
    {
        [Key]
        public int ID { get; set; }

        public string TesterName { get; set; }
    }
}