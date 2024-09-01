using System;
using System.Threading;
using System.Threading.Tasks;
using Passingwind.Abp.ElsaModule.Common;
using Passingwind.Abp.ElsaModule.Settings;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;

namespace Passingwind.Abp.ElsaModule.Cleanup;

public class CleanupSettingsManager : ICleanupSettingsManager, IScopedDependency
{
    protected ISettingProvider SettingProvider { get; }
    protected ISettingManager SettingManager { get; }
    protected ICurrentTenant CurrentTenant { get; }

    public CleanupSettingsManager(ISettingProvider settingProvider, ISettingManager settingManager, ICurrentTenant currentTenant)
    {
        SettingProvider = settingProvider;
        SettingManager = settingManager;
        CurrentTenant = currentTenant;
    }

    public async Task<CleanupSettings> GetAsync(CancellationToken cancellationToken = default)
    {
        return new CleanupSettings
        {
            Enabled = await GetValueAsync<bool>(ElsaModuleSettings.InstanceCleanup.Enabled),
            KeepDays = await GetValueAsync<int>(ElsaModuleSettings.InstanceCleanup.KeepDays),
            Scopes = await GetValueAsync<WorkflowInstanceCleanupScope>(ElsaModuleSettings.InstanceCleanup.Scopes),
            //OnlyCompleted = await GetValueAsync<bool>(ElsaModuleSettings.InstanceCleanup.OnlyCompleted),
        };
    }

    public async Task UpdateAsync(CleanupSettings settings, CancellationToken cancellationToken = default)
    {
        await SettingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, ElsaModuleSettings.InstanceCleanup.Enabled, settings.Enabled.ToString());
        await SettingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, ElsaModuleSettings.InstanceCleanup.KeepDays, settings.KeepDays.ToString());
        await SettingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, ElsaModuleSettings.InstanceCleanup.Scopes, settings.Scopes.ToString());
        //await SettingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, ElsaModuleSettings.InstanceCleanup.OnlyCompleted, settings.OnlyCompleted.ToString());
    }

    protected virtual async Task<T> GetValueAsync<T>(string key, T defaultValue = default) where T : struct
    {
        string value = await SettingProvider.GetOrNullAsync(key);
        if (string.IsNullOrWhiteSpace(value))
            return default;

        if (typeof(T).IsEnum)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        return value.To<T>();
    }
}