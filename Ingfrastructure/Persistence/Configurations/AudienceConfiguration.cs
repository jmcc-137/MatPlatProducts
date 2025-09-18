using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingfrastructure.Persistence.Configurations
{
    public class AudienceConfiguration : IEntityTypeConfiguration<Audience>
    {
        public void Configure(EntityTypeBuilder<Audience> builder)
        {
            builder.ToTable("audiences");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(60);
        }
    }
}
