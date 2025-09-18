using System.Collections.Generic;

namespace Domain.Entities
{
    public class MembershipPeriod
    {
        public int Id { get; set; }
        public int MembershipId { get; set; }
        public int PeriodId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string CompanyId { get; set; } = string.Empty;

        public Membership Membership { get; set; } = null!;
        public Period Period { get; set; } = null!;
        public Company Company { get; set; } = null!;
        public ICollection<MembershipBenefit> MembershipBenefits { get; set; } = new HashSet<MembershipBenefit>();
    }
}