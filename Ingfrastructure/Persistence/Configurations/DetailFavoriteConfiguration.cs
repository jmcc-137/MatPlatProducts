using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingfrastructure.Persistence.Configurations
{
    public class DetailFavoriteConfiguration : IEntityTypeConfiguration<DetailFavorite>
    {
        public void Configure(EntityTypeBuilder<DetailFavorite> builder)
        {
            builder.ToTable("details_favorites");
            builder.HasKey(df => df.Id);
            builder.HasOne(df => df.Favorite)
                .WithMany(f => f.DetailFavorites)
                .HasForeignKey(df => df.FavoriteId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(df => df.Product)
                .WithMany(p => p.DetailFavorites)
                .HasForeignKey(df => df.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
