using Volo.Abp.Authorization.Permissions;

namespace Passingwind.WorkflowApp.Permissions;

public class WorkflowAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(WorkflowAppPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(WorkflowAppPermissions.MyPermission1, L("Permission:MyPermission1"));
    }
}
