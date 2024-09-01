using System.Threading.Tasks;
using Passingwind.Abp.ElsaModule.Teams;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Identity;

namespace Passingwind.Abp.ElsaModule.EventHandlers;

public class RoleNameChangedHandler : IDistributedEventHandler<IdentityRoleNameChangedEto>, ITransientDependency
{
    protected IWorkflowTeamRepository WorkflowTeamRepository { get; }

    public RoleNameChangedHandler(IWorkflowTeamRepository workflowTeamRepository)
    {
        WorkflowTeamRepository = workflowTeamRepository;
    }

    public async Task HandleEventAsync(IdentityRoleNameChangedEto eventData)
    {
        var oldName = eventData.OldName;
        var newName = eventData.Name;

        await WorkflowTeamRepository.UpdateRoleNameAsync(oldName, newName);
    }
}
