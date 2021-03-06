﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Technica.Models
{
    public enum Power
    {
        Normal,
        Moderator,
        Administrator
    }

    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastAccessDate { get; set; }
        public string Phone { get; set; }
        public Power Power { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Wish> Wishes { get; set; }
    }
}