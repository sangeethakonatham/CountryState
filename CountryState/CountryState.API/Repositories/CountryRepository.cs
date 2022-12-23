using CountryState.API.Data;
using CountryState.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CountryState.API.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly CountryStateDbContext countryStateDbContext;

        public CountryRepository(CountryStateDbContext countryStateDbContext)
        {
            this.countryStateDbContext = countryStateDbContext;
        }
        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await countryStateDbContext.Countries.ToListAsync();
        }
    }
}
