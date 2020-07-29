using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimaryStorage.Entities;

namespace PrimaryStorage.EFConfigurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasIndex(i => i.Name).IsUnique();

            builder.ToTable("Songs");
        }
    }
}
