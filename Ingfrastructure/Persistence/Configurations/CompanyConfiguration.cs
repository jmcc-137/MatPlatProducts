using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingfrastructure.Persistence.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("companies");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(80);
            builder.Property(c => c.Cellphone)
                .HasMaxLength(15);
            builder.Property(c => c.Email)
                .HasMaxLength(85);
            builder.HasOne(c => c.Category)
                .WithMany(ca => ca.Companies)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.TypeIdentification)
                .WithMany()
                .HasForeignKey(c => c.TypeId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.City)
                .WithMany()
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Audience)
                .WithMany(a => a.Companies)
                .HasForeignKey(c => c.AudienceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
