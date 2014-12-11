using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Technica.Models;

namespace Technica.DAL
{
    public class TechnicaInitializer : DropCreateDatabaseIfModelChanges<TechnicaContext>
    {
        protected override void Seed(TechnicaContext context)
        {
            Address address = new Address { Country = "Turkey", City = "Sakarya", ZipCode = "54100", UserID=0};
            User user = new User { Email = "admin@admin.com", FirstName = "Admin", LastName = "istrator", LastAccessDate = DateTime.Now, RegistrationDate = DateTime.Now, Password = "admin", Phone = "555 444 33 22" };
            context.Addresses.Add(address);
            context.Users.Add(user);
        }
    }
}