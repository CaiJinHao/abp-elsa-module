using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Threading;

namespace Passingwind.Abp.ElsaModule.Cleanup;

public class CleanupBackgroundWorker : AsyncPeriodicBackgroundWorkerBase, ITransientDependency
{
    public CleanupBackgroundWorker(AbpAsyncTimer timer, IServiceScopeFactory serviceScopeFactory) : base(timer, serviceScopeFactory)
    {
        timer.Period = (int)TimeSpan.FromHours(6).TotalMilliseconds;
    }

    protected override async Task DoWorkAsync(PeriodicBackgroundWorkerContext workerContext)
    {
        var service = workerContext.ServiceProvider.GetRequiredService<ICleanupRunner>();

        try
        {
            await service.RunAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Executing workflow instance cleanup job failed.");
        }
    }
}
