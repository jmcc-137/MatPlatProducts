namespace Domain.Entities
{
    public class QualityProduct
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int PollId { get; set; }
        public string CompanyId { get; set; } = string.Empty;
        public DateTime DataRating { get; set; }
        public double Rating { get; set; }

        public Product Product { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
        public Poll Poll { get; set; } = null!;
        public Company Company { get; set; } = null!;
    }
}