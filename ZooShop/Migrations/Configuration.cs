namespace ZooShop.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZooShop.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZooShop.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ZooShop.Models.ApplicationDbContext context)
        {
            /*context.Animals.AddOrUpdate(x => x.AnimalId,
                new Animal() { AnimalId = 1, Name = "Bibi", Gender = "Female", Price = 300, Details = "Have long hair!", BreedId = 1, Vaccines = new List<Vaccine> { new Vaccine { Name = "Vaccine1", Price = 30 } } },
                new Animal() { AnimalId = 2, Name = "Tina", Gender = "Female", Price = 400, Details = "Have short hair!", BreedId = 2, Vaccines = new List<Vaccine> { new Vaccine { Name = "Vaccine2", Price = 30 } } });


            context.Breeds.AddOrUpdate(x => x.BreedId,
                new Breed() { BreedId = 1, BreedName = "Siameza" },
                new Breed() { BreedId = 2, BreedName = "Birmaneza" });

            context.Vaccines.AddOrUpdate(x => x.VaccineId,
                new Vaccine() { VaccineId = 1, Name = "Nobivac", Price = 200 },
                new Vaccine() { VaccineId = 2, Name = "FeliBio", Price = 249 });*/

        }
    }
}
