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

            context.Categories.Add(new Category { Name = "Camera", Image = "categories/camera.jpg" });
            context.Categories.Add(new Category { Name = "Phone", Image = "categories/phone.jpg" });
            context.Categories.Add(new Category { Name = "Computer", Image = "categories/computer.jpg" });
            context.Categories.Add(new Category { Name = "Console", Image = "categories/console.jpg" });
            context.Categories.Add(new Category { Name = "Television", Image = "categories/television.jpg" });
            context.Categories.Add(new Category { Name = "Games", Image = "categories/games.jpg" });

            context.Currencies.Add(new Currency { Name="Dollar", ShortName="&dollar;", Ratio=2.12m});
            context.Currencies.Add(new Currency { Name = "Türk Lirası", ShortName = "&#8378;", Ratio = 1m });
            context.Currencies.Add(new Currency { Name="Euro", ShortName="&euro;", Ratio=2.88m});
            context.Currencies.Add(new Currency { Name="Pound", ShortName="&pound;", Ratio=3.75m});

            context.Languages.Add(new Language { Name = "English", ShortName = "en", Culture = "en-US" });
            context.Languages.Add(new Language { Name = "Türkçe", ShortName = "tr", Culture = "tr-TR" });

            context.Products.Add(new Product { CategoryID = 1, Name = "Nikon D5100", Price = 1300m, Image = "product/d5100.jpg" });
            context.Products.Add(new Product { CategoryID = 1, Name = "Nikon D5300", Price = 2100m, Image = "product/d5300.jpg" });
            context.Products.Add(new Product { CategoryID = 4, Name = "xBox", Price = 750m, Image = "product/xbox.jpg" });
            context.Products.Add(new Product { CategoryID = 4, Name = "PlayStation 4", Price = 750m, OldPrice = 850m, Image = "product/ps4.jpg" });
            context.Products.Add(new Product { CategoryID = 2, Name = "ASUS Zenfone 5", Price = 699m, Image = "product/asuszenphone5.jpg" });
            context.Products.Add(new Product { CategoryID = 2, Name = "SAMSUNG I9060", Price = 599m, Image = "product/SAMSUNGI9060.jpg" });
            context.Products.Add(new Product { CategoryID = 2, Name = "SAMSUNG I8200", Price = 549m, Image = "product/SAMSUNGI8200.jpg" });
            context.Products.Add(new Product { CategoryID = 2, Name = "SAMSUNG S5611", Price = 349m, Image = "product/SAMSUNGS5611.jpg" });
            context.Products.Add(new Product { CategoryID = 2, Name = "IPHONE 5S 16 GB", Price = 1749m, Image = "product/IPHONE5S16GB.jpg" });
            context.Products.Add(new Product { CategoryID = 2, Name = "Discovery 2", Price = 888m, Image = "product/General Mobile Discovery 2.jpg" });
            context.Products.Add(new Product { CategoryID = 2, Name = "IPHONE 6 16 GB", Price = 2349m, Image = "product/IPHONE 6 16 GB.jpg" });
            context.Products.Add(new Product { CategoryID = 3, Name = "LENOVO Z5070", Price = 2048m, Image = "product/LENOVO Z5070.jpg" });
            context.Products.Add(new Product { CategoryID = 3, Name = "HP 15-R103NT ", Price = 1648m, Image = "product/HP 15-R103NT.jpg" });
            context.Products.Add(new Product { CategoryID = 2, Name = "CASPER VIA V8", Price = 1199m, Image = "product/CASPER VIA V8.jpg" });
            context.Products.Add(new Product { CategoryID = 2, Name = "CASPER VIA V5", Price = 1199m, Image = "product/CASPER VIA V5.jpg" });
            context.Products.Add(new Product { CategoryID = 3, Name = "CASPER CN-VSM4210X", Price = 1399m, Image = "product/CASPER CN-VSM4210X.jpg" });
            context.Products.Add(new Product { CategoryID = 3, Name = "ASUS N550JK", Price = 3349m, Image = "product/ASUS N550JK.jpg" });
            context.Products.Add(new Product { CategoryID = 3, Name = "HP 15-R113NT ", Price = 1699m, Image = "product/HP 15-R113NT.jpg" });
            context.Products.Add(new Product { CategoryID = 3, Name = "ASUS X553MA", Price = 925m, Image = "product/ASUS X553MA.jpg" });
            context.Products.Add(new Product { CategoryID = 5, Name = "SUNNY 42''", Price = 949m, Image = "product/SUNNY 42.jpg" });
            context.Products.Add(new Product { CategoryID = 5, Name = "SEG 32SD5150", Price = 649m, Image = "product/SEG 32SD5150.jpg" });
            context.Products.Add(new Product { CategoryID = 6, Name = "PS4 GTA V", Price = 250m, Image = "product/ps4gtav.jpg" });
            context.Products.Add(new Product { CategoryID = 6, Name = "WARLORDS OF DRAENOR", Price = 160m, Image = "product/wowwod.jpg" });
            context.Products.Add(new Product { CategoryID = 6, Name = "ASSASSINS CREED UNITY", Price = 250m, Image = "product/acunity.jpg" });
            context.Products.Add(new Product { CategoryID = 6, Name = "PS3 FAR CRY 4", Price = 220m, Image = "product/ps3fc4.jpg" });
            context.Products.Add(new Product { CategoryID = 1, Name = "Nikon D4S", Price = 2700m, Image = "product/d4s.jpg" });

            context.Users.Add(new User { Email = "admin@admin.com", FirstName = "Admin", LastName = "istrator", LastAccessDate = DateTime.Now, RegistrationDate = DateTime.Now, Password = "admin", Phone = "555 444 33 22", Power=Power.Administrator });
        }
    }
}