using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalculation.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Holiday> Holidays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed country

            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, Name = "Turkey", Currency = "TR" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, Name = "United Arab Emirates", Currency = "AE" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 3, Name = "China ", Currency = "TW" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 4, Name = "German", Currency = "DE" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 5, Name = "Denmark", Currency = "DK" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 6, Name = "UnitedState", Currency = "US" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 7, Name = "France", Currency = "FR" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 8, Name = "Italy", Currency = "IT" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 9, Name = "Japan", Currency = "JP" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 10, Name = "Korea", Currency = "KR" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 11, Name = "Russia", Currency = "RU" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 12, Name = "India", Currency = "IN" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 13, Name = "Egypt", Currency = "EG" });




            //seed holidays
            modelBuilder.Entity<Holiday>().HasData(new Holiday { HolidayId = 1, Name = "Eid", Date = new DateTime(2022, 11, 1), CountryId = 1 });
            modelBuilder.Entity<Holiday>().HasData(new Holiday { HolidayId = 2, Name = "Eid", Date = new DateTime(2022, 11, 2), CountryId = 1 });
            modelBuilder.Entity<Holiday>().HasData(new Holiday { HolidayId = 3, Name = "Eid", Date = new DateTime(2022, 11, 3), CountryId = 1 });
          

        }
    }
}


