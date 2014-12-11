using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Technica.Models
{
    public class Currency
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public decimal Ratio { get; set; }
    }
}