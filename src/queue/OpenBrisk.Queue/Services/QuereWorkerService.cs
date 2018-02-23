using System.Threading;
using System.Threading.Tasks;

namespace OpenBrisk.Queue.Services
{
    public class QuereWorkerService : HostedService
    {
        public QuereWorkerService()
        {
        }

        protected override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}