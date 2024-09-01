using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Passingwind.Abp.ElsaModule.Settings;

public interface IWorkflowSettingsAppService : IApplicationService
{
    Task<CleanupSettingsDto> GetCleanupAsync();
    Task UpdateCleanupAsync(CleanupSettingsDto input);
}
