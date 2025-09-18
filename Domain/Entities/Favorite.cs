using System.Collections.Generic;

namespace Domain.Entities
{
    public class Favorite
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CompanyId { get; set; } = string.Empty;

        public Customer Customer { get; set; } = null!;
        public Company Company { get; set; } = null!;
        public ICollection<DetailFavorite> DetailFavorites { get; set; } = new HashSet<DetailFavorite>();
    }
}