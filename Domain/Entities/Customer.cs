using System.Collections.Generic;

namespace Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CityId { get; set; } = string.Empty;
        public int AudienceId { get; set; }
        public string Cellphone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public Audience Audience { get; set; } = null!;
        public ICollection<Favorite> Favorites { get; set; } = new HashSet<Favorite>();
        public ICollection<Rate> Rates { get; set; } = new HashSet<Rate>();
        public ICollection<QualityProduct> QualityProducts { get; set; } = new HashSet<QualityProduct>();
    }
}