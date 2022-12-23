namespace CountryState.API.Models.Domain
{
    public class Country
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Double Population { get; set; }
        //navigation property
        public IEnumerable<State> States { get; set; }
    }
}
