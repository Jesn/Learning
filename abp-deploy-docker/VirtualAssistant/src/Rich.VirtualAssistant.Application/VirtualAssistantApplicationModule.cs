using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Rich.VirtualAssistant;

[DependsOn(
    typeof(VirtualAssistantDomainModule),
    typeof(VirtualAssistantApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class VirtualAssistantApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<VirtualAssistantApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<VirtualAssistantApplicationModule>(validate: true);
        });
    }
}
