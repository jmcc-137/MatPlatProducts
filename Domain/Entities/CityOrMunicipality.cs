namespace Domain.Entities
{
    public class CityOrMunicipality
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string StateRegId { get; set; } = string.Empty;

        public StateRegion StateRegion { get; set; } = null!;
    }
}