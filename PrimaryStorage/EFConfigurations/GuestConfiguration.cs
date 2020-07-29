using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimaryStorage.Entities;

namespace PrimaryStorage.EFConfigurations
{
    internal class GuestConfiguration : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.HasKey(i => i.Id);

            builder.ToTable("Guests");
        }
    }
}