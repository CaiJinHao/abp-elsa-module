using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;

namespace Passingwind.Abp.ElsaModule.Cleanup;

public class WorkflowInstanceCleanupBackgroundJob : AsyncBackgroundJob<WorkflowInstanceCleanupBackgroundJobArgs>, ITransientDependency
{
    private IWorkflowInstanceCleanupProvider WorkflowInstanceCleanupProvider { get; }

    public WorkflowInstanceCleanupBackgroundJob(IWorkflowInstanceCleanupProvider workflowInstanceCleanupProvider)
    {
        WorkflowInstanceCleanupProvider = workflowInstanceCleanupProvider;
    }

    public override async Task ExecuteAsync(WorkflowInstanceCleanupBackgroundJobArgs args)
    {
        var id = args.Id;
        var scope = args.Scope;

        try
        {
            await WorkflowInstanceCleanupProvider.CleanupAsync(id, scope);
        }
        catch (System.Exception ex)
        {
            Logger.LogError(ex, "Workflow instance with id '{Id}' cleanup failed.", id);
        }
    }
}
