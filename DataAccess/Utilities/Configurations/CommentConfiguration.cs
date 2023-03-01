using Entity.Concrete;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Utilities.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(c => c.Message).HasMaxLength(255).IsRequired();
        builder.Property(c => c.SendedDate).HasDefaultValue(DateTime.Now);
        builder.Property(c => c.isDeleted).HasDefaultValue(false);
        
    }
}
