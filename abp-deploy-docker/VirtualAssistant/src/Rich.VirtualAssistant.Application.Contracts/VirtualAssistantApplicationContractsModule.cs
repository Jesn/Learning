using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Rich.VirtualAssistant;

[DependsOn(
    typeof(VirtualAssistantDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class VirtualAssistantApplicationContractsModule : AbpModule
{

}
