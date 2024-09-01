using System;
using Passingwind.Abp.ElsaModule.Common;

namespace Passingwind.Abp.ElsaModule.Cleanup;

public class WorkflowInstanceCleanupBackgroundJobArgs
{
    public WorkflowInstanceCleanupBackgroundJobArgs(Guid id, WorkflowInstanceCleanupScope scope)
    {
        Id = id;
        Scope = scope;
    }

    public Guid Id { get; }
    public WorkflowInstanceCleanupScope Scope { get; }
}