using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingfrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(80);
            builder.Property(c => c.Cellphone)
                .HasMaxLength(20);
            builder.Property(c => c.Email)
                .HasMaxLength(100);
            builder.Property(c => c.Address)
                .HasMaxLength(120);
            builder.HasOne(c => c.Audience)
                .WithMany(a => a.Customers)
                .HasForeignKey(c => c.AudienceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
