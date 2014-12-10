using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Technica.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastAccessDate { get; set; }
        public DateTime CellPhone { get; set; }
        public virtual ICollection<Adress> Adresses { get; set; }
    }
}