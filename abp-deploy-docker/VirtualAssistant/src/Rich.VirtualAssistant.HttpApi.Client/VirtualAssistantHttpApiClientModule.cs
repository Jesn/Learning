using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Rich.VirtualAssistant;

[DependsOn(
    typeof(VirtualAssistantApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class VirtualAssistantHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(VirtualAssistantApplicationContractsModule).Assembly,
            VirtualAssistantRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<VirtualAssistantHttpApiClientModule>();
        });

    }
}
