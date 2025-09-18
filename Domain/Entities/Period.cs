using System.Collections.Generic;

namespace Domain.Entities
{
    public class Period
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<MembershipPeriod> MembershipPeriods { get; set; } = new HashSet<MembershipPeriod>();
    }
}