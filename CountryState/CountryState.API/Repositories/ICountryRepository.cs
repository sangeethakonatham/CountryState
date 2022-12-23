using CountryState.API.Models.Domain;

namespace CountryState.API.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllAsync();
    }
}
