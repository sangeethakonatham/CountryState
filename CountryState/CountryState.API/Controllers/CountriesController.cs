using AutoMapper;
using CountryState.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CountryState.API.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountryRepository countryRepository;
        private readonly IMapper mapper;


        //constructor
        public CountriesController(ICountryRepository countryRepository,IMapper mapper)
        {
            this.countryRepository=countryRepository;
            this.mapper = mapper;
        }

        

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await countryRepository.GetAllAsync();
            var countriesDTO = mapper.Map<List<Models.DTO.Country>>(countries);
            return Ok(countriesDTO);
        }
    }
}
