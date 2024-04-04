using MVCStartApp.Models.Db;
using System.Threading.Tasks;

namespace MVCStartApp.Repositories
{
    public interface IRequestRepository
    {
        Task WriteRequest(Request request);
        Task<Request[]> GetRequets();
    }
}
