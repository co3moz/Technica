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

        public decimal Price { get; set; }
        public int CurrencyID { get; set; }

        public DateTime Date { get; set; }

        public string JsonProducts { get; set; }
        public string JsonAdress { get; set; }
    }
}