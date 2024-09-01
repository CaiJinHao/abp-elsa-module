using System.Threading.Tasks;
using Elsa.Scripting.JavaScript.Services;
using Microsoft.Extensions.DependencyInjection;
using Passingwind.Abp.ElsaModule.Cleanup;
using Passingwind.Abp.ElsaModule.CSharp;
using Passingwind.Abp.ElsaModule.Permissions;
using Passingwind.Abp.ElsaModule.Services;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Caching;
using Volo.Abp.Domain;
using Volo.Abp.Identity;
using Volo.Abp.Json;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;

namespace Passingwind.Abp.ElsaModule;

[DependsOn(
    typeof(ElsaModuleDomainSharedModule),
    typeof(AbpBackgroundWorkersModule),
    typeof(AbpCachingModule),
    typeof(AbpDddDomainModule),
    typeof(AbpIdentityDomainModule),
    typeof(AbpJsonModule),
    typeof(AbpPermissionManagementDomainModule),
    typeof(AbpSettingManagementDomainModule)
)]
public class ElsaModuleDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ElsaModuleDomainModule).Assembly));

        context.Services.AddTransient<IWorkflowCSharpEditorService, NullMonacoEditorService>();

        Configure<PermissionManagementOptions>(options =>
        {
            options.IsDynamicPermissionStoreEnabled = true;
            options.ManagementProviders.Add<WorkflowTeamPermissionManagementProvider>();
            options.ManagementProviders.Add<WorkflowUserOwnerPermissionManagementProvider>();
        });

        Configure<AbpPermissionOptions>(options =>
        {
            options.ValueProviders.Add<WorkflowTeamPermissionValueProvider>();
            options.ValueProviders.Add<WorkflowUserOwnerPermissionValueProvider>();
        });
    }

    public override void PostConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.Replace<Elsa.Services.IIdGenerator, AbpElsaIdGenerator>(ServiceLifetime.Singleton);
        context.Services.Replace<Elsa.Services.ITenantAccessor, AbpElsaTenantAccessor>(ServiceLifetime.Transient);
        context.Services.Replace<Elsa.Services.IWorkflowFactory, NewWorkflowFactory>(ServiceLifetime.Transient);
        context.Services.Replace<IConvertsJintEvaluationResult, SystemTextJsonJintConverter>(ServiceLifetime.Singleton);
        // context.Services.Replace<IContentSerializer, AbpContentSerializer>(ServiceLifetime.Singleton);
    }

    public override async Task OnPostApplicationInitializationAsync(Volo.Abp.ApplicationInitializationContext context)
    {
        await context.AddBackgroundWorkerAsync<CleanupBackgroundWorker>();
    }
}
