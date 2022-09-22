using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Rich.VirtualAssistant;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(VirtualAssistantDomainSharedModule)
)]
public class VirtualAssistantDomainModule : AbpModule
{

}
