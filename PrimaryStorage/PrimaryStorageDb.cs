using PrimaryStorage.EFConfigurations;
using PrimaryStorage.Entities;
using Microsoft.EntityFrameworkCore;

namespace PrimaryStorage
{
    public class PrimaryStorageDb : DbContext, IPrimaryStorageDb
    {
        public PrimaryStorageDb(DbContextOptions<PrimaryStorageDb> options)
            : base(options)
        { }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<GuestComment> GuestComments { get; set; }

        #region MODEL DESCRIPTION

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.ApplyConfiguration(new GuestCommentConfiguration());
            modelBuilder.ApplyConfiguration(new GuestConfiguration());
            modelBuilder.ApplyConfiguration(new SongConfiguration());
        }

        #endregion MODEL DESCRIPTION
    }
}