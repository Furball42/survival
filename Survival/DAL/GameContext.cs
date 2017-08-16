using Microsoft.AspNet.Identity.EntityFramework;
using Survival.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Survival.DAL
{
    public class GameContext : DbContext
    {
         public GameContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Character> Characters { get; set; }
        //public DbSet<Gear> Gear { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<RarityType> RarityTypes { get; set; }
        public DbSet<WildlifeType> WildlifeTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationType> LocationTypes { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<AreaWeather> Weathers { get; set; }
        public DbSet<AreaTemperature> Temperatures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        //public System.Data.Entity.DbSet<Survival.Models.Wilderness> Wildernesses { get; set; }
    }
}