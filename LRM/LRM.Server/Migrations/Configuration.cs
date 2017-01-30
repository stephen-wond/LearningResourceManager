using LRM.Server.Models;

namespace LRM.Server.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Server.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<LRMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LRMContext context)
        {
            context.Resources.AddOrUpdate(x => x.Id,
              new Resource() { Id = 1, Name = "Using Web API 2 with Entity Framework 6", Link = @"https://www.asp.net/web-api/overview/data/using-web-api-with-entity-framework/part-1", Description = "This tutorial will teach you the basics of creating a web application with an ASP.NET Web API back end. The tutorial uses Entity Framework 6 for the data layer, and Knockout.js for the client-side JavaScript application. The tutorial also shows how to deploy the app to Azure App Service Web Apps.", Keywords = "Web API Enitiy Framework ASP.NET Models Controllers POCOs Data Context Seed"},
              new Resource() { Id = 2, Name = "TEST ITEM 1", Link = "NOT A REAL LINK", Description = "Just a test item for filler", Keywords = "Random Key Words That Relate To Nothing Interesting" },
              new Resource() { Id = 3, Name = "Getting Started with ASP.NET Web API 2", Link = "https://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api", Description = "ASP.NET Web API is a framework for building web APIs on top of the .NET Framework. In this tutorial, you will use ASP.NET Web API to create a web API that returns a list of products.", Keywords = "ASP.NET Web API Visual Studio Models Controllers " },
              new Resource() { Id = 4, Name = "TEST ITEM 2", Link = "ANOTHER UNREAL LINK", Description = "All filler, no thriller", Keywords = "No More Seeded Entries After This Please" }
            );

        }
    }
}
