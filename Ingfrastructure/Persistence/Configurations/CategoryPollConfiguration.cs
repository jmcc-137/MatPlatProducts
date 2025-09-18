using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingfrastructure.Persistence.Configurations
{
    public class CategoryPollConfiguration : IEntityTypeConfiguration<CategoryPoll>
    {
        public void Configure(EntityTypeBuilder<CategoryPoll> builder)
        {
            builder.ToTable("categories_polls");
            builder.HasKey(cp => cp.Id);
            builder.Property(cp => cp.Name)
                .IsRequired()
                .HasMaxLength(80);
        }
    }
}
