using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingfrastructure.Persistence.Configurations
{
    public class BenefitConfiguration : IEntityTypeConfiguration<Benefit>
    {
        public void Configure(EntityTypeBuilder<Benefit> builder)
        {
            builder.ToTable("benefits");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(80);
            builder.Property(b => b.Detail)
                .HasMaxLength(200);
        }
    }
}
