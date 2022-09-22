using Rich.VirtualAssistant.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Rich.VirtualAssistant.Permissions;

public class VirtualAssistantPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(VirtualAssistantPermissions.GroupName, L("Permission:VirtualAssistant"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<VirtualAssistantResource>(name);
    }
}
