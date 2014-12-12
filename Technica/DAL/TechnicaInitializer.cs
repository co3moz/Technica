using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Technica.Models;

namespace Technica.DAL
{
    public class TechnicaInitializer : DropCreateDatabaseIfModelChanges<TechnicaContext>
    {
        public override void InitializeDatabase(TechnicaContext context)
        {
            SqlConnection.ClearAllPools();
            base.InitializeDatabase(context);
        }
        protected override void Seed(TechnicaContext context)
        {
            SqlConnection.ClearAllPools();

            Debug.WriteLine("Technica Initializing..");

            context.Categories.Add(new Category { Name = "Camera" });
            context.Categories.Add(new Category { Name = "Phone" });
            context.Categories.Add(new Category { Name = "Computer" });
            context.Categories.Add(new Category { Name = "Camera" });
            context.Categories.Add(new Category { Name = "Console" });
            context.Categories.Add(new Category { Name = "Television" });

            context.Currencies.Add(new Currency { Name="Dollar", ShortName="&dollar;", Ratio=2m, Culture="en-US"});
            context.Currencies.Add(new Currency { Name="Türk Lirası", ShortName="TL", Ratio=1m, Culture="tr-TR"});
            context.Currencies.Add(new Currency { Name="Euro", ShortName="&euro;", Ratio=3m, Culture="de-DE"});
            context.Currencies.Add(new Currency { Name="Pound", ShortName="&pound;", Ratio=3m, Culture="en-GB"});

            context.Languages.Add(new Language { Name = "Türkçe", ShortName = "TR", Culture = "tr-TR" });
            context.Languages.Add(new Language { Name = "English", ShortName = "EN", Culture = "en-US" });

            context.Shippings.Add(new Shipping { Name = "Aras Kargo", Price = 5m, Active=true });
            context.Shippings.Add(new Shipping { Name = "MNG Kargo", Price = 8m, Active = true });
            context.Shippings.Add(new Shipping { Name = "Yurtiçi Kargo", Price = 7m, Active = true });

            context.Addresses.Add(new Address { Country = "Turkey", City = "Sakarya", ZipCode = "54100"});
            context.Users.Add(new User { Email = "admin@admin.com", FirstName = "Admin", LastName = "istrator", LastAccessDate = DateTime.Now, RegistrationDate = DateTime.Now, Password = "admin", Phone = "555 444 33 22", Power=Power.Administrator });
        }
    }
}