using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingfrastructure.Persistence.Configurations
{
    public class TypeIdentificationConfiguration : IEntityTypeConfiguration<TypeIdentification>
    {
        public void Configure(EntityTypeBuilder<TypeIdentification> builder)
        {
            builder.ToTable("typeidentifications");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Description)
                .IsRequired();
            builder.Property(t => t.Suffix)
                .HasMaxLength(5);
        }
    }
}
