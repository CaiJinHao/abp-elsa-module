using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;

namespace Passingwind.Abp.ElsaModule.Cleanup;

public class CleanupRunner : ICleanupRunner, IScopedDependency
{
    protected ILogger<CleanupRunner> Logger { get; }
    protected IClock Clock { get; }
    protected ICleanupSettingsManager CleanupSettingsManager { get; }
    protected IWorkflowInstanceCleanupProvider InstanceCleanupProvider { get; }

    public CleanupRunner(ILogger<CleanupRunner> logger, IClock clock, ICleanupSettingsManager cleanupSettingsManager, IWorkflowInstanceCleanupProvider instanceCleanupProvider)
    {
        Logger = logger;
        Clock = clock;
        CleanupSettingsManager = cleanupSettingsManager;
        InstanceCleanupProvider = instanceCleanupProvider;
    }

    public virtual async Task RunAsync(bool fource = false, CancellationToken cancellationToken = default)
    {
        var settings = await CleanupSettingsManager.GetAsync(cancellationToken);

        if (!settings.Enabled && !fource)
        {
            Logger.LogDebug("Cleanup settings are not enabled.");
            return;
        }

        var endDate = Clock.Now.Date.AddDays(-settings.KeepDays);

        await InstanceCleanupProvider.ExecutingAsync(endDate, settings.Scopes, cancellationToken);
    }
}