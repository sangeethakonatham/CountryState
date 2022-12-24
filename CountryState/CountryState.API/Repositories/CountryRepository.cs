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

        public async Task<Country> AddAsync(Country country)
        {
            country.Id = Guid.NewGuid();
            await countryStateDbContext.AddAsync(country);
            await countryStateDbContext.SaveChangesAsync();
            return country;
            
        }

        public async Task<Country> DeleteAsync(Guid id)
        {
            var country = await countryStateDbContext.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if(country==null)
            {
                return null;
            }
            countryStateDbContext.Countries.Remove(country);
            await countryStateDbContext.SaveChangesAsync();
            return country;

        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await countryStateDbContext.Countries.ToListAsync();
        }

        public async Task<Country> GetAsync(Guid id)
        {
            return await countryStateDbContext.Countries.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Country> UpdateAsync(Guid id, Country country)
        {
            var existingCountry = await countryStateDbContext.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if(existingCountry==null) 
            {
                return null;
            }
            
            existingCountry.Name= country.Name;
            existingCountry.Population= country.Population;
            await countryStateDbContext.SaveChangesAsync();
            return existingCountry;

        }
    }
}
