using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingfrastructure.Persistence.Configurations
{
    public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("favorites");
            builder.HasKey(f => f.Id);
            builder.HasOne(f => f.Customer)
                .WithMany(c => c.Favorites)
                .HasForeignKey(f => f.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(f => f.Company)
                .WithMany()
                .HasForeignKey(f => f.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
