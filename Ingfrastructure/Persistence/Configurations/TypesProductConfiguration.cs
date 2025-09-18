using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingfrastructure.Persistence.Configurations
{
    public class TypesProductConfiguration : IEntityTypeConfiguration<TypesProduct>
    {
        public void Configure(EntityTypeBuilder<TypesProduct> builder)
        {
            builder.ToTable("typesproducts");
            builder.HasKey(tp => tp.Id);
            builder.Property(tp => tp.Description)
                .IsRequired()
                .HasMaxLength(80);
        }
    }
}
