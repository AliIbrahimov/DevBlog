using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Utilities.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.Property(c=>c.Subject).HasMaxLength(255);
        builder.Property(c=>c.Message).IsRequired().HasMaxLength(255);
        builder.Property(c => c.Email).IsRequired().HasMaxLength(255);
        builder.Property(c => c.CreatedDate).IsRequired().HasDefaultValue(DateTime.Now);
        builder.Property(c => c.IsDeleted).HasDefaultValue(false);
        builder.Property(c => c.FullName).HasMaxLength(255);

    }
}
