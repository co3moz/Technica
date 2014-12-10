using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Technica.Models
{
    public class Order
    {
        public int UserID { get; set; }
        public int BasketID { get; set; }
        public int OrderID { get; set; }
        public decimal OrderPrice { get; set; }
        public string OrderAdress { get; set; }
        public string OrderAdress2 { get; set; }

        public string OrderCity { get; set; }
        public string OrderZip { get; set; }
        public string OrderPhone { get; set; }
        public decimal OrderShiping { get; set; }
        public decimal OrderTax { get; set; }
        public string OrderEmail { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Basket> ProductsInBasket { get; set; }
        public virtual ICollection<Product> Products { get; set; }


    }
}