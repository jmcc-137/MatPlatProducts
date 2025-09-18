using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingfrastructure.Persistence.Configurations
{
    public class PollConfiguration : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            builder.ToTable("polls");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(80);
            builder.Property(p => p.Description)
                .HasMaxLength(200);
            builder.Property(p => p.IsActive)
                .IsRequired();
            builder.HasOne(p => p.CategoryPoll)
                .WithMany(cp => cp.Polls)
                .HasForeignKey(p => p.CategoryPollId);
        }
    }
}
