using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TestAirports.Models;

namespace TestAirports
{
    public class SQLiteContext: IdentityDbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; } 
        public DbSet<Airport> Airports { get; set; }
        public SQLiteContext(DbContextOptions<SQLiteContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
