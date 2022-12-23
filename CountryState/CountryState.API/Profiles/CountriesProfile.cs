using AutoMapper;

namespace CountryState.API.Profiles
{
    public class CountriesProfile:Profile
    {
        public CountriesProfile()
        {
            CreateMap<Models.Domain.Country, Models.DTO.Country>()
                .ReverseMap();
        }
    }
}
