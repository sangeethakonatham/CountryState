using CountryState.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CountryState.API.Data
{
    public class CountryStateDbContext : DbContext
    {
        public CountryStateDbContext(DbContextOptions<CountryStateDbContext> options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
    
    }
    
       
   
}
