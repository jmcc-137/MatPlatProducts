using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingfrastructure.Persistence.Configurations
{
    public class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.ToTable("rates");
            builder.HasKey(r => new { r.CustomerId, r.CompanyId, r.PollId });
            builder.Property(r => r.DataRating)
                .IsRequired();
            builder.Property(r => r.Rating)
                .IsRequired();
            builder.HasOne(r => r.Customer)
                .WithMany(c => c.Rates)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(r => r.Company)
                .WithMany()
                .HasForeignKey(r => r.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(r => r.Poll)
                .WithMany(p => p.Rates)
                .HasForeignKey(r => r.PollId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
