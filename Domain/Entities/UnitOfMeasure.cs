using System.Collections.Generic;

namespace Domain.Entities
{
    public class UnitOfMeasure
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public ICollection<CompanyProduct> CompanyProducts { get; set; } = new HashSet<CompanyProduct>();
    }
}