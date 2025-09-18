using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingfrastructure.Persistence.Configurations
{
    public class MembershipBenefitConfiguration : IEntityTypeConfiguration<MembershipBenefit>
    {
        public void Configure(EntityTypeBuilder<MembershipBenefit> builder)
        {
            builder.ToTable("membershipbenefits");
            builder.HasKey(mb => mb.Id);
            builder.HasOne(mb => mb.MembershipPeriod)
                .WithMany(mp => mp.MembershipBenefits)
                .HasForeignKey(mb => mb.MembershipPeriodId);
            builder.HasOne(mb => mb.Benefit)
                .WithMany(b => b.MembershipBenefits)
                .HasForeignKey(mb => mb.BenefitId);
        }
    }
}
