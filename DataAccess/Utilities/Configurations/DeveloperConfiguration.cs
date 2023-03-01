using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Utilities.Configurations;

public class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
{
    public void Configure(EntityTypeBuilder<Developer> builder)
    {
       /* builder.Property(c=>c.UserName).IsRequired().HasMaxLength(255);
        builder.Property(c=>c.Name).HasMaxLength(255);
        builder.Property(c=>c.Surname).HasMaxLength(255);
        builder.Property(c=>c.Email).HasMaxLength(255).IsRequired();
        builder.Property(c=>c.Adress).HasMaxLength(255);
        builder.Property(c=>c.Position).HasMaxLength(255);
        builder.Property(c => c.PhoneNumber).HasMaxLength(255);*/
    }
}
