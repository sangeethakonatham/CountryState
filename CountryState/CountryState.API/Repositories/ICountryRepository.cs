using CountryState.API.Models.Domain;

namespace CountryState.API.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllAsync();
        Task<Country> GetAsync(Guid id);
        Task<Country> AddAsync(Country country);
        Task<Country> DeleteAsync(Guid id);
        Task<Country> UpdateAsync(Guid id,Country country);
    }
}
