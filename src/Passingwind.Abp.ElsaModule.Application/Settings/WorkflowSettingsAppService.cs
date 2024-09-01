using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Passingwind.Abp.ElsaModule.Cleanup;
using Passingwind.Abp.ElsaModule.Common;
using Passingwind.Abp.ElsaModule.Permissions;

namespace Passingwind.Abp.ElsaModule.Settings;

[Authorize(ElsaModulePermissions.Settings.Default)]
public class WorkflowSettingsAppService : ElsaModuleAppService, IWorkflowSettingsAppService
{
    protected ICleanupSettingsManager CleanupSettingsManager { get; }

    public WorkflowSettingsAppService(ICleanupSettingsManager cleanupSettingsManager)
    {
        CleanupSettingsManager = cleanupSettingsManager;
    }

    [Authorize(ElsaModulePermissions.Settings.InstanceCleanup)]
    public virtual async Task<CleanupSettingsDto> GetCleanupAsync()
    {
        var settings = await CleanupSettingsManager.GetAsync();

        var scopes = settings.Scopes;

        return new CleanupSettingsDto()
        {
            Enabled = settings.Enabled,
            KeepDays = settings.KeepDays,
            ScopeAll = scopes.HasFlag(WorkflowInstanceCleanupScope.All),
            Scopes = Enum.GetValues<WorkflowInstanceCleanupScope>().Cast<WorkflowInstanceCleanupScope>().Where(x => scopes.HasFlag(x)).Cast<int>().ToArray(),
        };
    }

    [Authorize(ElsaModulePermissions.Settings.InstanceCleanup)]
    public virtual async Task UpdateCleanupAsync(CleanupSettingsDto input)
    {
        await CleanupSettingsManager.UpdateAsync(new CleanupSettings
        {
            Enabled = input.Enabled,
            KeepDays = input.KeepDays,
            Scopes = input.ScopeAll ? WorkflowInstanceCleanupScope.All : (WorkflowInstanceCleanupScope)input.Scopes.Sum(),
        });
    }
}
