using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week2_Assignment.Models;

namespace Week2_Assignment.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id).IsRequired(true);
        builder.Property(x => x.Username).IsRequired(true).HasMaxLength(10);
        builder.Property(x => x.Password).IsRequired(true).HasMaxLength(20);

        builder.HasIndex(x => new { x.Id }).IsUnique(true);
    }
}