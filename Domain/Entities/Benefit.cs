using System.Collections.Generic;

namespace Domain.Entities
{
    public class Benefit
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Detail { get; set; } = string.Empty;

        public ICollection<MembershipBenefit> MembershipBenefits { get; set; } = new HashSet<MembershipBenefit>();
        public ICollection<AudienceBenefit> AudienceBenefits { get; set; } = new HashSet<AudienceBenefit>();
    }
}