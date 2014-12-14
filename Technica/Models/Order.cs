using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Technica.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int UserID { get; set; }

        public int Count { get; set; }
        public decimal Price { get; set; }
        public int CurrencyID { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string ActualAddress { get; set; }
        public string ZipCode { get; set; }

        public DateTime Date { get; set; }
        
        public string JsonProducts { get; set; }
        public string Notes { get; set; }
        public bool Hidden { get; set; }
    }
}