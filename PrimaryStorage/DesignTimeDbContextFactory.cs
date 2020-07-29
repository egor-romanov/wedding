using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PrimaryStorage
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PrimaryStorageDb>
    {
        public PrimaryStorageDb CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PrimaryStorageDb>();
            var connectionString = "Host=localhost;Port=5432;Database=PrimaryStorage;Username=sa;Password=qwerty`123";
            builder.UseNpgsql(connectionString);
            return new PrimaryStorageDb(builder.Options);
        }
    }
}
