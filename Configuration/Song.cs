using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week2_Assesment.Models;

namespace Week2_Assessment.Configuration;

public class SongConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.Property(x => x.Name).IsRequired(true);
        builder.Property(x => x.Id).IsRequired(true);
        builder.Property(x => x.Album).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.Band).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.ReleaseYear).IsRequired(true).HasMaxLength(4);

        builder.HasIndex(x => new { x.Id }).IsUnique(true);
    }
}