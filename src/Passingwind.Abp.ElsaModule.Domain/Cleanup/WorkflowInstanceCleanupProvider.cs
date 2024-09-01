using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Passingwind.Abp.ElsaModule.Common;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;

namespace Passingwind.Abp.ElsaModule.Cleanup;

public class WorkflowInstanceCleanupProvider : IWorkflowInstanceCleanupProvider, IScopedDependency
{
    protected ILogger<WorkflowInstanceCleanupProvider> Logger { get; }
    protected IBackgroundJobManager BackgroundJobManager { get; }
    protected IWorkflowInstanceRepository WorkflowInstanceRepository { get; }
    protected IWorkflowExecutionLogRepository WorkflowExecutionLogRepository { get; }

    public WorkflowInstanceCleanupProvider(
        ILogger<WorkflowInstanceCleanupProvider> logger,
        IWorkflowInstanceRepository workflowInstanceRepository,
        IBackgroundJobManager backgroundJobManager,
        IWorkflowExecutionLogRepository workflowExecutionLogRepository)
    {
        Logger = logger;
        WorkflowInstanceRepository = workflowInstanceRepository;
        BackgroundJobManager = backgroundJobManager;
        WorkflowExecutionLogRepository = workflowExecutionLogRepository;
    }

    public virtual async Task ExecutingAsync(DateTime endDate, WorkflowInstanceCleanupScope cleanupScope, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation("Start cleaning workflow instance data...");

        var ids = new List<Guid>();

        ids.AddRange(await WorkflowInstanceRepository.GetIdsAsync(status: WorkflowInstanceStatus.Faulted, maxFaultedTime: endDate, cancellationToken: cancellationToken));
        ids.AddRange(await WorkflowInstanceRepository.GetIdsAsync(status: WorkflowInstanceStatus.Cancelled, maxCancelledTime: endDate, cancellationToken: cancellationToken));
        ids.AddRange(await WorkflowInstanceRepository.GetIdsAsync(status: WorkflowInstanceStatus.Finished, maxFinishedTime: endDate, cancellationToken: cancellationToken));

        foreach (var item in ids)
        {
            await BackgroundJobManager.EnqueueAsync(new WorkflowInstanceCleanupBackgroundJobArgs(item, cleanupScope));
        }
    }

    public virtual async Task CleanupAsync(Guid id, WorkflowInstanceCleanupScope cleanupScope, CancellationToken cancellationToken = default)
    {
        Logger.LogDebug("Start cleanup workflow instance with id '{Id}'", id);

        if (cleanupScope.HasFlag(WorkflowInstanceCleanupScope.All))
        {
            await WorkflowExecutionLogRepository.DeleteDirectAsync(x => x.WorkflowInstanceId == id, cancellationToken);
            await WorkflowInstanceRepository.DeleteDirectAsync(x => x.Id == id, cancellationToken);
        }
        else
        {
            await WorkflowInstanceRepository.CleanupAsync(
                id,
                input: cleanupScope.HasFlag(WorkflowInstanceCleanupScope.Input),
                output: cleanupScope.HasFlag(WorkflowInstanceCleanupScope.Output),
                faults: cleanupScope.HasFlag(WorkflowInstanceCleanupScope.Faults),
                variables: cleanupScope.HasFlag(WorkflowInstanceCleanupScope.Variables),
                metadata: cleanupScope.HasFlag(WorkflowInstanceCleanupScope.Metadata),
                activityScopes: cleanupScope.HasFlag(WorkflowInstanceCleanupScope.ActivityScopes),
                activityData: cleanupScope.HasFlag(WorkflowInstanceCleanupScope.ActivityData),
                logs: cleanupScope.HasFlag(WorkflowInstanceCleanupScope.ExecutionLogs),
                cancellationToken: cancellationToken);
        }
    }
}
