using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingfrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(60);
            builder.Property(p => p.Detail)
                .HasMaxLength(200);
            builder.Property(p => p.Price)
                .IsRequired();
            builder.Property(p => p.Image)
                .HasMaxLength(80);
            builder.HasOne(p => p.TypesProduct)
                .WithMany(tp => tp.Products)
                .HasForeignKey(p => p.TypeProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
