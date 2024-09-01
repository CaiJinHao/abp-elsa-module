using System.Threading;
using System.Threading.Tasks;

namespace Passingwind.Abp.ElsaModule.Cleanup;

public interface ICleanupRunner
{
    Task RunAsync(bool fource = false, CancellationToken cancellationToken = default);
}
