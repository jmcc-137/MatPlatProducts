using System.Collections.Generic;

namespace Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public ICollection<Company> Companies { get; set; } = new HashSet<Company>();
    }
}