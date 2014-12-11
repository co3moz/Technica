using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Technica.Models;

namespace Technica.DAL
{
    public class TechnicaInitializer : DropCreateDatabaseIfModelChanges<TechnicaContext>
    {
        protected override void Seed(TechnicaContext context)
        {
            SqlConnection.ClearAllPools();
            context.Categories.Add(new Category { Name = "Camera" });
            context.Categories.Add(new Category { Name = "Phone" });
            context.Categories.Add(new Category { Name = "Computer" });
            context.Categories.Add(new Category { Name = "Camera" });
            context.Categories.Add(new Category { Name = "Console" });
            context.Categories.Add(new Category { Name = "Television" });

            context.Currencies.Add(new Currency{ Name="Dollar", ShortName="$", Ratio=2m, Culture="en-US"});
            context.Currencies.Add(new Currency{ Name="Türk Lirası", ShortName="TL", Ratio=1m, Culture="tr-TR"});
            context.Currencies.Add(new Currency{ Name="Euro", ShortName="€", Ratio=3m, Culture="de-DE"});
            context.Currencies.Add(new Currency{ Name="Pound", ShortName="", Ratio=3m, Culture="en-GB"});

            context.Languages.Add(new Language { Name = "Türkçe", ShortName = "TR", Culture = "tr-TR" });
            context.Languages.Add(new Language { Name = "English", ShortName = "EN", Culture = "en-US" });

            context.Addresses.Add(new Address { Country = "Turkey", City = "Sakarya", ZipCode = "54100"});
            context.Users.Add( new User { Email = "admin@admin.com", FirstName = "Admin", LastName = "istrator", LastAccessDate = DateTime.Now, RegistrationDate = DateTime.Now, Password = "admin", Phone = "555 444 33 22" });
        }
    }
}