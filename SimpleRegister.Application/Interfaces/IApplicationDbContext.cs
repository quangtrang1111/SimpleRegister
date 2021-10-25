using System.Threading;
using System.Threading.Tasks;

namespace SimpleRegister.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
