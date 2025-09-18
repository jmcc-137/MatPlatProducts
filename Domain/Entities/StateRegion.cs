using System.Collections.Generic;

namespace Domain.Entities
{
    public class StateRegion
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string CountryId { get; set; } = string.Empty;
        public string Code3166 { get; set; } = string.Empty;
        public string StateRegId { get; set; } = string.Empty;
        public int? SubdivisionId { get; set; }

        public Country Country { get; set; } = null!;
        public ICollection<CityOrMunicipality> CitiesOrMunicipalities { get; set; } = new HashSet<CityOrMunicipality>();
    }
}