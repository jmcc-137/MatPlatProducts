using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingfrastructure.Persistence.Configurations
{
    public class CompanyProductConfiguration : IEntityTypeConfiguration<CompanyProduct>
    {
        public void Configure(EntityTypeBuilder<CompanyProduct> builder)
        {
            builder.ToTable("companyproducts");
            builder.HasKey(cp => new { cp.CompanyId, cp.ProductId });
            builder.Property(cp => cp.Price)
                .IsRequired();
            builder.HasOne(cp => cp.Company)
                .WithMany(c => c.CompanyProducts)
                .HasForeignKey(cp => cp.CompanyId);
            builder.HasOne(cp => cp.Product)
                .WithMany(p => p.CompanyProducts)
                .HasForeignKey(cp => cp.ProductId);
            builder.HasOne(cp => cp.UnitOfMeasure)
                .WithMany(u => u.CompanyProducts)
                .HasForeignKey(cp => cp.UnitMeasureId);
        }
    }
}
