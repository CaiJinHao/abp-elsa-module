using System.Threading;
using System.Threading.Tasks;

namespace Passingwind.Abp.ElsaModule.Cleanup;

public interface ICleanupSettingsManager
{
    Task<CleanupSettings> GetAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(CleanupSettings settings, CancellationToken cancellationToken = default);
}
