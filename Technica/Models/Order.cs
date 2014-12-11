using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Technica.Models
{
    public class Order
    {

        public int ID { get; set; }
        public int UserID { get; set; }

        public decimal Price { get; set; }
        public int CurrencyID { get; set; }

        public string Country { get; set; }
        public string City { get; set; }

        public decimal OrderShiping { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Product> Products { get; set; }


    }
}