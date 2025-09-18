using System.Collections.Generic;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } =  string.Empty;
        public string Detail { get; set; } = string.Empty;
        public double Price { get; set; }
        public int TypeProductId { get; set; }
        public string Image { get; set; } = string.Empty;

        public TypesProduct TypesProduct { get; set; } = null!;
        public ICollection<CompanyProduct> CompanyProducts { get; set; } = new HashSet<CompanyProduct>();
        public ICollection<DetailFavorite> DetailFavorites { get; set; } = new HashSet<DetailFavorite>();
        public ICollection<QualityProduct> QualityProducts { get; set; } = new HashSet<QualityProduct>();
    }
}