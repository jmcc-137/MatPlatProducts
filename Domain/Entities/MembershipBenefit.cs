namespace Domain.Entities
{
    public class MembershipBenefit
    {
        public int Id { get; set; }
        public int MembershipPeriodId { get; set; }
        public int BenefitId { get; set; }

        public MembershipPeriod MembershipPeriod { get; set; } = null!;
        public Benefit Benefit { get; set; } = null!;
    }
}