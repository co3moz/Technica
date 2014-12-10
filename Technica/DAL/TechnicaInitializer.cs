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
        }
    }
}