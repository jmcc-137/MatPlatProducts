using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingfrastructure.Persistence.Configurations
{
    public class QualityProductConfiguration : IEntityTypeConfiguration<QualityProduct>
    {
        public void Configure(EntityTypeBuilder<QualityProduct> builder)
        {
            builder.ToTable("quality_products");
            builder.HasKey(qp => new { qp.ProductId, qp.CustomerId, qp.PollId, qp.CompanyId });
            builder.Property(qp => qp.DataRating)
                .IsRequired();
            builder.Property(qp => qp.Rating)
                .IsRequired();
            builder.HasOne(qp => qp.Product)
                .WithMany(p => p.QualityProducts)
                .HasForeignKey(qp => qp.ProductId);
            builder.HasOne(qp => qp.Customer)
                .WithMany(c => c.QualityProducts)
                .HasForeignKey(qp => qp.CustomerId);
            builder.HasOne(qp => qp.Poll)
                .WithMany(p => p.QualityProducts)
                .HasForeignKey(qp => qp.PollId);
            builder.HasOne(qp => qp.Company)
                .WithMany()
                .HasForeignKey(qp => qp.CompanyId);
        }
    }
}
