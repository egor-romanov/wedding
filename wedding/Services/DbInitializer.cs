using System.Threading.Tasks;
using PrimaryStorage;

namespace wedding.Services
{
    public class DbInitializer : IDbInitializer
    {
        public async Task Initialize(PrimaryStorageDb context)
        {
            await context.Database.EnsureCreatedAsync();
        }
    }
}