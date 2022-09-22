using Localization.Resources.AbpUi;
using Rich.VirtualAssistant.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Rich.VirtualAssistant;

[DependsOn(
    typeof(VirtualAssistantApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class VirtualAssistantHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(VirtualAssistantHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<VirtualAssistantResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
