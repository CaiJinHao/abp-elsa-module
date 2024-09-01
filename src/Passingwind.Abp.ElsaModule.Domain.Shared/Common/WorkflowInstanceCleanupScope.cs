using System;

namespace Passingwind.Abp.ElsaModule.Common;

[Flags]
public enum WorkflowInstanceCleanupScope
{
    None = 0,
    Input = 1,
    Output = 1 << 1,
    Faults = 1 << 2,
    Variables = 1 << 3,
    Metadata = 1 << 4,
    ActivityScopes = 1 << 5,
    ActivityData = 1 << 6,
    ExecutionLogs = 1 << 7,
    All = 1 << 16,
}