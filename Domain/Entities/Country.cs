using System.Collections.Generic;

namespace Domain.Entities
{
    public class Country
    {
        public string IsoCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string AlfaSoftTwo { get; set; } = string.Empty;
        public string AlfaSofThree { get; set; } = string.Empty;

        public ICollection<StateRegion> StateRegions { get; set; } = new HashSet<StateRegion>();
    }
}