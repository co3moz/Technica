using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Technica.Models
{
    public class Basket
    {
        public int ProductID { get; set; }
        public int BasketID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}