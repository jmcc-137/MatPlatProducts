using System.Collections.Generic;

namespace Domain.Entities
{
    public class TypesProduct
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}