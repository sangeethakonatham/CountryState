using AutoMapper;
using CountryState.API.Models.DTO;
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
        public CountriesController(ICountryRepository countryRepository, IMapper mapper)
        {
            this.countryRepository = countryRepository;
            this.mapper = mapper;
        }

        //Get all Regions
        [HttpGet]
        public async Task<IActionResult> GetAllCountriesAsync()
        {
            var countries = await countryRepository.GetAllAsync();
            var countriesDTO = mapper.Map<List<Models.DTO.Country>>(countries);
            return Ok(countriesDTO);
        }

        //Get Region by id
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetCountryAsync")]
        public async Task<IActionResult> GetCountryAsync(Guid id)
        {
            var country = await countryRepository.GetAsync(id);
            if(country == null)
            {
                return NotFound();
            }
            
            var countryDTO = mapper.Map<Models.DTO.Country>(country);
            return Ok(countryDTO);
        }

        //Add region
        [HttpPost]
        public async Task<IActionResult>AddCountryAsync(Models.DTO.AddCountryRequest addCountryRequest)
        {
            var country = new Models.Domain.Country()
            {
                Name = addCountryRequest.Name,
                Population = addCountryRequest.Population
            };
            country= await countryRepository.AddAsync(country);
            var countryDTO=new Models.DTO.Country
            {
                Name = country.Name,
                Population = country.Population
            };
            return CreatedAtAction(nameof(GetCountryAsync),new {id=countryDTO.Id }, countryDTO);

        }

        //Delete region by id
        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult>DeleteCountryAsync(Guid id)
        {

            var country = await countryRepository.DeleteAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            var countryDTO = new Models.DTO.Country
            {
                Id=country.Id,  
                Name = country.Name,
                Population = country.Population

            };
            return Ok(countryDTO);  

        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult>UpdateCountryAsync([FromRoute]Guid id, [FromBody]Models.DTO.UpdateCountryRequest updateCountryRequest)
        {
            var country = new Models.Domain.Country()
            {
                Name = updateCountryRequest.Name,
                Population = updateCountryRequest.Population
            };
            country = await countryRepository.UpdateAsync(id,country);
            if(country==null)
            {
                return NotFound();
            }
            var countryDTO = new Models.DTO.Country
            {
                Name = country.Name,
                Population = country.Population
            };
            return Ok(countryDTO);

        }


    }
}
