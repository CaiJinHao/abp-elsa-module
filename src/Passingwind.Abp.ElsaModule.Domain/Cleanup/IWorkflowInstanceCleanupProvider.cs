using System;
using System.Threading;
using System.Threading.Tasks;
using Passingwind.Abp.ElsaModule.Common;

namespace Passingwind.Abp.ElsaModule.Cleanup;

public interface IWorkflowInstanceCleanupProvider
{
    Task CleanupAsync(Guid id, WorkflowInstanceCleanupScope cleanupScope, CancellationToken cancellationToken = default);
    Task ExecutingAsync(DateTime endDate, WorkflowInstanceCleanupScope cleanupScope, CancellationToken cancellationToken = default);
}
