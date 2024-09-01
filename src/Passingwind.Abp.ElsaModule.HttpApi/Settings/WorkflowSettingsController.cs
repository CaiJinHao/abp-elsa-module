using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace Passingwind.Abp.ElsaModule.Settings;

[Area(ElsaModuleRemoteServiceConsts.RemoteServiceName)]
[RemoteService(Name = ElsaModuleRemoteServiceConsts.RemoteServiceName)]
[Route("api/elsa/workflow/settings")]
public class WorkflowSettingsController : ElsaModuleController, IWorkflowSettingsAppService
{
    protected IWorkflowSettingsAppService Service { get; }

    public WorkflowSettingsController(IWorkflowSettingsAppService service)
    {
        Service = service;
    }

    [HttpGet("cleanup")]
    public virtual Task<CleanupSettingsDto> GetCleanupAsync()
    {
        return Service.GetCleanupAsync();
    }

    [HttpPost("cleanup")]
    public virtual Task UpdateCleanupAsync(CleanupSettingsDto input)
    {
        return Service.UpdateCleanupAsync(input);
    }
}
