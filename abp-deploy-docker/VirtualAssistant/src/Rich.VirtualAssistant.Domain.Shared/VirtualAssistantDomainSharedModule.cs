using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Rich.VirtualAssistant.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Rich.VirtualAssistant;

[DependsOn(
    typeof(AbpValidationModule)
)]
public class VirtualAssistantDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<VirtualAssistantDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<VirtualAssistantResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/VirtualAssistant");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("VirtualAssistant", typeof(VirtualAssistantResource));
        });
    }
}
