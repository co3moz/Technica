﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Technica.Models
{
    public class Product
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}