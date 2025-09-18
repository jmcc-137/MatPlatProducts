namespace Domain.Entities
{
    public class CompanyProduct
    {
        public string CompanyId { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int UnitMeasureId { get; set; }

        public Company Company { get; set; } = null!;
        public Product Product { get; set; } = null!;
        public UnitOfMeasure UnitOfMeasure { get; set; } = null!;
    }
}