using System.Threading.Tasks;
using PrimaryStorage;

namespace wedding.Services
{
    public interface IDbInitializer
    {
        Task Initialize(PrimaryStorageDb context);
    }
}
