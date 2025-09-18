using System.Collections.Generic;

namespace Domain.Entities
{
    public class Company
    {
        public string Id { get; set; } = string.Empty;
        public int TypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string CityId { get; set; } = string.Empty;
        public int AudienceId { get; set; }
        public string Cellphone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public TypeIdentification TypeIdentification { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public CityOrMunicipality City { get; set; } = null!;
        public Audience Audience { get; set; } = null!;
        public ICollection<CompanyProduct> CompanyProducts { get; set; } = new HashSet<CompanyProduct>();
        public ICollection<MembershipPeriod> MembershipPeriods { get; set; } = new HashSet<MembershipPeriod>();
    }
}