using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StatisticsHub.API.Models
{
    public class Team
    {
        public int ID { get; set; }
        public string Team_ID { get; set; }
        public string Abbreviation { get; set; }
        public bool Active{ get; set; }
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }
        [Required]
        public string Conference { get; set; }
        [Required]
        public string Division { get; set; }
        [Required]
        public string Site_Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Full_Name { get; set; }
    }
}