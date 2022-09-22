using Volo.Abp.Reflection;

namespace Rich.VirtualAssistant.Permissions;

public class VirtualAssistantPermissions
{
    public const string GroupName = "VirtualAssistant";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(VirtualAssistantPermissions));
    }
}
