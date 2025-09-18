namespace Domain.Entities
{
    public class Rate
    {
        public int CustomerId { get; set; }
        public string CompanyId { get; set; } = string.Empty;
        public int PollId { get; set; }
        public DateTime DataRating { get; set; }
        public double Rating { get; set; }

        public Customer Customer { get; set; } = null!;
        public Company Company { get; set; } = null!;
        public Poll Poll { get; set; } = null!;
    }
}