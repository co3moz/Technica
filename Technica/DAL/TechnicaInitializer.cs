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

            context.Categories.Add(new Category { Name = "Camera", Image="camera.jpg" });
            context.Categories.Add(new Category { Name = "Phone", Image = "phone.jpg" });
            context.Categories.Add(new Category { Name = "Computer", Image = "computer.jpg" });
            context.Categories.Add(new Category { Name = "Console", Image = "console.jpg" });
            context.Categories.Add(new Category { Name = "Television", Image = "television.jpg" });
            context.Categories.Add(new Category { Name = "Games", Image = "games.jpg" });

            context.Currencies.Add(new Currency { Name="Dollar", ShortName="&dollar;", Ratio=2m, Culture="en-US"});
            context.Currencies.Add(new Currency { Name = "Türk Lirası", ShortName = "&#8378;", Ratio = 1m, Culture = "tr-TR" });
            context.Currencies.Add(new Currency { Name="Euro", ShortName="&euro;", Ratio=3m, Culture="de-DE"});
            context.Currencies.Add(new Currency { Name="Pound", ShortName="&pound;", Ratio=3m, Culture="en-GB"});

            context.Languages.Add(new Language { Name = "English", ShortName = "en", Culture = "en-US" });
            context.Languages.Add(new Language { Name = "Türkçe", ShortName = "tr", Culture = "tr-TR" });

            context.Shippings.Add(new Shipping { Name = "Aras Cargo", Price = 5m, Active=true });
            context.Shippings.Add(new Shipping { Name = "MNG Cargo", Price = 8m, Active = true });
            context.Shippings.Add(new Shipping { Name = "Yurtiçi Cargo", Price = 7m, Active = true });

            context.Products.Add(new Product { CategoryID = 1, Name = "Nikon D5100", Price = 1300m, Image = "product/d5100.jpg" });
            context.Products.Add(new Product { CategoryID = 1, Name = "Nikon D5300", Price = 2100m, Image = "product/d5300.jpg" });
            context.Products.Add(new Product { CategoryID = 4, Name = "XBox", Price = 750m, Image = "product/xbox.jpg" });
            context.Products.Add(new Product { CategoryID = 4, Name = "Ps4", Price = 750m, Image = "product/ps4.jpg" });

            context.Addresses.Add(new Address { Country = "Turkey", City = "Sakarya", ZipCode = "54100"});
            context.Users.Add(new User { Email = "admin@admin.com", FirstName = "Admin", LastName = "istrator", LastAccessDate = DateTime.Now, RegistrationDate = DateTime.Now, Password = "admin", Phone = "555 444 33 22", Power=Power.Administrator });
        }
    }
}