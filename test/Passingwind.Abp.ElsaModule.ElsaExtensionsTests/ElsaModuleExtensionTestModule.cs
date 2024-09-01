using Passingwind.CSharpScriptEngine;
using Volo.Abp.Modularity;

namespace Passingwind.Abp.ElsaModule;

[DependsOn(
    typeof(ElsaModuleExtensionModule),
    typeof(ElsaModuleDomainTestModule)
    )]
public class ElsaModuleExtensionTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddCSharpScriptEngine();
    }
}
