using Rich.VirtualAssistant.Localization;
using Volo.Abp.Application.Services;

namespace Rich.VirtualAssistant;

public abstract class VirtualAssistantAppService : ApplicationService
{
    protected VirtualAssistantAppService()
    {
        LocalizationResource = typeof(VirtualAssistantResource);
        ObjectMapperContext = typeof(VirtualAssistantApplicationModule);
    }
}
