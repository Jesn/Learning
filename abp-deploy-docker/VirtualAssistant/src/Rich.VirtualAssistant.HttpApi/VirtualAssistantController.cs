using Rich.VirtualAssistant.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Rich.VirtualAssistant;

public abstract class VirtualAssistantController : AbpControllerBase
{
    protected VirtualAssistantController()
    {
        LocalizationResource = typeof(VirtualAssistantResource);
    }
}
