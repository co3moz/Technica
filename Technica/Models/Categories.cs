using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Technica.Models
{
    public class Categories
    {
        public int ProductCategoriID { get; set; }
        public string CategoriName { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}