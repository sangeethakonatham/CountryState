using CountryState.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CountryState.API.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountryRepository countryRepository;

        //constructor
        public CountriesController(ICountryRepository countryRepository)
        {
            this.countryRepository=countryRepository;
            this.countryRepository = countryRepository;
        }
        [HttpGet]
        public IActionResult GetAllCountries()
        {
            var countries = countryRepository.GetAll();
            return Ok(countries);
        }
    }
}
