using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Utilities.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.Property(c => c.Name).HasMaxLength(255);
        builder.Property(c => c.Description).IsRequired();
        builder.Property(c => c.CreatedDate).HasDefaultValue(DateTime.Now);
        builder.Property(c => c.IsDeleted).HasDefaultValue(false);
    }
}
