namespace CountryState.API.Models.Domain
{
    public class State
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Double Population { get; set; }
        public Guid CountryId { get; set; }
        //navigation property
        public Country Country { get; set; }
    }
}
