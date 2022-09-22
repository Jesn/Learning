using Volo.Abp.Modularity;

namespace Rich.VirtualAssistant;

[DependsOn(
    typeof(VirtualAssistantApplicationModule),
    typeof(VirtualAssistantDomainTestModule)
    )]
public class VirtualAssistantApplicationTestModule : AbpModule
{

}
