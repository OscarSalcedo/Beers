namespace Beers.Migrations.Migrations
{
    using Context;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContextDecorator>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContextDecorator context)
        {
            var beerTypeList = new List<BeerType>
            {
                new BeerType { Id = Guid.Parse("FBC09C5B-2CEA-46D5-A6DF-4616DEAD0CD3"), Name="Rubia"},
                new BeerType {Id = Guid.Parse("83EBD55A-B80C-46CE-A970-6E032650270F"),Name="Negra"},
                new BeerType {Id = Guid.Parse("A06BFB33-0753-4FAC-B05F-3C49C5A21FAD"),Name="Tostada"}
            };

            beerTypeList.ForEach(f => context.BeerType.AddOrUpdate(f));

            var countryList = new List<Country>
            {
                new Country { Id = Guid.Parse("C8089196-EEC2-4D22-AFC4-128E5B18FD9E"), Name="España"},
                new Country { Id = Guid.Parse("27BBEFCC-C3C7-462B-8C60-1D8E376770DE"), Name="Francia"},
                new Country { Id = Guid.Parse("728F49F9-6052-4DCF-B714-61C41E6A1131"), Name="Portugal"},
                new Country { Id = Guid.Parse("AD6490F8-65E0-44A0-9932-20D79C7AA8E1"), Name="Alemania"},
                new Country { Id = Guid.Parse("7DD3BA82-7BDA-4E1C-A545-0D32262F61A9"), Name="Italia"}

            };
            countryList.ForEach(f => context.Country.AddOrUpdate(f));
            context.SaveChanges();

            var cityList = new List<City>
            {
                new City { Id = Guid.Parse("D9B921D7-6BED-499C-8A35-5C4A92C7AD67"), Name="Barcelona", Country = context.Country.FirstOrDefault(f=> f.Name == "España")},
                new City { Id = Guid.Parse("2BC02FC4-D681-419D-A3DB-431B56C0ACCC"), Name="Zaragoza",Country = context.Country.FirstOrDefault(f=> f.Name == "España")},
                new City { Id= Guid.Parse("EB078FEA-C60F-4E2F-AF5D-5CCB5E2DE692"), Name="Reims", Country = context.Country.FirstOrDefault(f=> f.Name == "Francia")},
                new City { Id= Guid.Parse("7AE0A8D5-ACB5-42ED-B04B-4C01B906961C"), Name="Paris", Country = context.Country.FirstOrDefault(f=> f.Name == "Francia")},
                new City { Id= Guid.Parse("BDBEBDE1-B930-476F-97ED-44461339032C"), Name="Fatima", Country = context.Country.FirstOrDefault(f=> f.Name == "Portugal")},
                new City { Id= Guid.Parse("12DC287C-9C89-4C24-A6C7-0EFA562831C8"), Name="Oporto", Country = context.Country.FirstOrDefault(f=> f.Name == "Portugal")},                
                new City { Id= Guid.Parse("B4843031-1D74-4DF9-B627-675EF0C371F6"), Name="Düsseldorf", Country = context.Country.FirstOrDefault(f=> f.Name == "Alemania")},
                new City { Id= Guid.Parse("DDD27683-087F-4994-B0A2-D6F02D0661ED"), Name="Berlin", Country = context.Country.FirstOrDefault(f=> f.Name == "Alemania")},
                new City { Id= Guid.Parse("1CB7270D-406C-4497-AEFF-80CBBD13CA09"), Name="Padua", Country = context.Country.FirstOrDefault(f=> f.Name == "Italia")},
                new City { Id= Guid.Parse("1D2C654D-45DC-4583-A2C4-6A0D14CD5BAA"), Name="Roma", Country = context.Country.FirstOrDefault(f=> f.Name == "Italia")}
            };
            cityList.ForEach(f => context.City.AddOrUpdate(f));
            context.SaveChanges();

            var tapasList = new List<Tapas>
            {
                new Tapas { Id = Guid.Parse("F43D82C9-5F88-4867-9BEF-64C4E9D5156B"), Name="Tortilla", Price=2},
                new Tapas { Id = Guid.Parse("52681C45-69CF-4E44-8619-B721988730A2"), Name="Jamon", Price=3},
                new Tapas { Id = Guid.Parse("4906C3A5-A68F-4839-A979-8AF610175C4E"), Name="Pulpo", Price=5}

            };
            tapasList.ForEach(f => context.Tapas.AddOrUpdate(f));
            context.SaveChanges();

        }
    }
}
