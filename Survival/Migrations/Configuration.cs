namespace Survival.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Survival.DAL.GameContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Survival.DAL.GameContext context)
        {
            bool bDoSeed = false;

            if(bDoSeed)
            {
                //ITEM TYPES
                context.ItemTypes.AddOrUpdate(
                      p => p.Description,
                      new Models.ItemType { Id = Guid.NewGuid(), Description = "Meat" },
                      new Models.ItemType { Id = Guid.NewGuid(), Description = "Hide" },
                      new Models.ItemType { Id = Guid.NewGuid(), Description = "Food" },
                      new Models.ItemType { Id = Guid.NewGuid(), Description = "Clothing" },
                      new Models.ItemType { Id = Guid.NewGuid(), Description = "Survival" },
                      new Models.ItemType { Id = Guid.NewGuid(), Description = "Outdoor" }
                );

                //WILDLIFE
                context.WildlifeTypes.AddOrUpdate(
                    p => p.Description,
                    new Models.WildlifeType { Id = Guid.NewGuid(), Description = "Deer", BaseHuntValue = 30, Icon = "", FindChanceValue = 30, ItemTypes = null },
                    new Models.WildlifeType { Id = Guid.NewGuid(), Description = "Wolf", BaseHuntValue = 10, Icon = "", FindChanceValue = 20, ItemTypes = null }
                );
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
