using System.Collections.Generic;

namespace Domain.Entities
{
    public class Audience
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public ICollection<Company> Companies { get; set; } = new HashSet<Company>();
        public ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
        public ICollection<AudienceBenefit> AudienceBenefits { get; set; } = new HashSet<AudienceBenefit>();
    }
}