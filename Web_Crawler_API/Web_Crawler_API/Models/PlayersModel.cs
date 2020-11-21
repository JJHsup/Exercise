using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Crawler_API.Models
{
    public class PlayersModel
    {
        [Key]
        public int ID { get; set; }

        public string PlayerName { get; set; }
        public float G { get; set; }
        public float PTS { get; set; }
        public float TRB { get; set; }
        public float AST { get; set; }
        public float FG { get; set; }
        public float FG3 { get; set; }
        public float FT { get; set; }
        public float eFG { get; set; }
        public float PER { get; set; }
        public float WS { get; set; }
    }
}