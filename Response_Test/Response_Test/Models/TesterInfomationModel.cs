using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Response_Test.Models
{
    public class TesterInfomationModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Name")]
        public string TesterName { get; set; }


        public DateTime Login { get; set; }
    }
}