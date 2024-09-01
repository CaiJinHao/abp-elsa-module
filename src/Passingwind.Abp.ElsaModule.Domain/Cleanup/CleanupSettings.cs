using Passingwind.Abp.ElsaModule.Common;

namespace Passingwind.Abp.ElsaModule.Cleanup;

public class CleanupSettings
{
    public bool Enabled { get; set; }
    public int KeepDays { get; set; }
    public WorkflowInstanceCleanupScope Scopes { get; set; }
    //public bool OnlyCompleted { get; set; }
}