using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingfrastructure.Persistence.Configurations
{
    public class MembershipPeriodConfiguration : IEntityTypeConfiguration<MembershipPeriod>
    {
        public void Configure(EntityTypeBuilder<MembershipPeriod> builder)
        {
            builder.ToTable("membershipperiods");
            builder.HasKey(mp => mp.Id);
            builder.Property(mp => mp.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(mp => mp.Price)
                .IsRequired();
            builder.HasOne(mp => mp.Membership)
                .WithMany(m => m.MembershipPeriods)
                .HasForeignKey(mp => mp.MembershipId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(mp => mp.Period)
                .WithMany(p => p.MembershipPeriods)
                .HasForeignKey(mp => mp.PeriodId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(mp => mp.Company)
                .WithMany(c => c.MembershipPeriods)
                .HasForeignKey(mp => mp.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
