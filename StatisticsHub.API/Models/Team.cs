using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatisticsHub.API.Models
{
    public class Team
    {
        public string Team_ID { get; set; }
        public string Abbreviation { get; set; }
        public bool Active{ get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        public string Site_Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Full_Name { get; set; }
    }
}