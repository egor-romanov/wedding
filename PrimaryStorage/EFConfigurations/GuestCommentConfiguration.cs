using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimaryStorage.Entities;

namespace PrimaryStorage.EFConfigurations
{
    internal class GuestCommentConfiguration : IEntityTypeConfiguration<GuestComment>
    {
        public void Configure(EntityTypeBuilder<GuestComment> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.Guest).WithMany(i => i.GuestComments).HasForeignKey(i => i.GuestId);

            builder.ToTable("GuestComments");
        }
    }
}