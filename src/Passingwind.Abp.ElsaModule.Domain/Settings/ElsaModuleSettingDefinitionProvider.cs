using Volo.Abp.Settings;

namespace Passingwind.Abp.ElsaModule.Settings;

public class ElsaModuleSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        context.Add(new SettingDefinition(ElsaModuleSettings.InstanceCleanup.Enabled, bool.FalseString));
        context.Add(new SettingDefinition(ElsaModuleSettings.InstanceCleanup.KeepDays, "30"));
        context.Add(new SettingDefinition(ElsaModuleSettings.InstanceCleanup.Scopes, null));
    }
}
