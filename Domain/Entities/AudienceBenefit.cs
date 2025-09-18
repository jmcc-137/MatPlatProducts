namespace Domain.Entities
{
    public class AudienceBenefit
    {
        public int AudienceId { get; set; }
        public int BenefitId { get; set; }

        public Audience Audience { get; set; } = null!;
        public Benefit Benefit { get; set; } = null!;
    }
}