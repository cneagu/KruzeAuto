using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KruzeAuto.API.Models
{
    public class MainSearch
    {
        public int Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Registration { get; set; }
        public int Price { get; set; }
        public int Km { get; set; }
        public string[] Fuel { get; set; }
        public string Condition { get; set; }
    }
}