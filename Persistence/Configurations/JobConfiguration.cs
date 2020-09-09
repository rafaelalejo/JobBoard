using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            // Primary key
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id)
                .ValueGeneratedOnAdd();

            // Properties
            builder.Property(j => j.Title)
                .IsRequired();
            builder.Property(j => j.Description)
                .IsRequired();
        }
    }
}
