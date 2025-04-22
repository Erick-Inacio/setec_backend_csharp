using System.Threading.Tasks;
using setec_backend_csharp.Models.Core;
using SetecBackendCSharp.Models.Core;
using SetecBackendCSharp.Repositories.Bases;

namespace SetecBackendCSharp.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> FindByUid(string Uid);
    }
}