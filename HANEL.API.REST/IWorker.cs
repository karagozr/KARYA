using System.Threading;
using System.Threading.Tasks;

namespace HANEL.API.REST
{
    public interface IWorker
    {
        Task DoWork(CancellationToken cancellationToken);

    }
}