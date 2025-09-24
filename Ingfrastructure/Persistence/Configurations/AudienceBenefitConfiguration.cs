using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingfrastructure.Persistence.Configurations
{
    public class AudienceBenefitConfiguration : IEntityTypeConfiguration<AudienceBenefit>
    {
        public void Configure(EntityTypeBuilder<AudienceBenefit> builder)
        {
            builder.ToTable("audiencebenefits");
            builder.HasKey(ab => new { ab.AudienceId, ab.BenefitId });
            builder.HasOne(ab => ab.Audience)
                .WithMany(a => a.AudienceBenefits)
                .HasForeignKey(ab => ab.AudienceId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(ab => ab.Benefit)
                .WithMany(b => b.AudienceBenefits)
                .HasForeignKey(ab => ab.BenefitId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
