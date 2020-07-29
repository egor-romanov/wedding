using PrimaryStorage.Entities;
using Microsoft.EntityFrameworkCore;

namespace PrimaryStorage
{
    public interface IPrimaryStorageDb
    {
        DbSet<Guest> Guests { get; set; }
        DbSet<Song> Songs { get; set; }
        DbSet<GuestComment> GuestComments { get; set; }
    }
}