using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Technica.Models
{
   public class Adress
    {
        public int AdressID { get; set; }
        public int UserID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Full { get; set; }
    }
}
