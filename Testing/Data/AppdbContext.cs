using Microsoft.EntityFrameworkCore;
using System;
using Testing.Data.Entities;

namespace Testing.Data
{
    public class AppdbContext : DbContext
    {
        public readonly IConfiguration _configuration;
        public DbSet<City> cities { get; set; }
        public DbSet<Region> regions { get; set; }
        public DbSet<Location> locations { get; set; }
        public AppdbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
