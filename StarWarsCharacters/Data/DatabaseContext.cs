using System;
using System.Collections.Generic;
using System.Text;
//using System.Data.Entity;
using StarWarsCharacters.Models;
using Microsoft.EntityFrameworkCore;

namespace StarWarsCharacters.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        public DatabaseContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = StarWars; Trusted_Connection = true");


        }
    }
}
