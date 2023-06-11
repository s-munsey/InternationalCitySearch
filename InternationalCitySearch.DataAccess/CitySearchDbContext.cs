using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalCitySearch.DataAccess
{
    public class CitySearchDbContext: DbContext
    {
        public CitySearchDbContext(DbContextOptions<CitySearchDbContext> options) : base(options) { }

        public DbSet<string> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<string>().HasData(
              "BANDUNG", "BANGUI", "BANGKOK", "BANGALORE",
              "LA PAZ", "LA PLATA", "LAGOS", "LEEDS",
              "ZARIA", "ZHUGAI", "ZIBO"
            );
        }

    }
}
