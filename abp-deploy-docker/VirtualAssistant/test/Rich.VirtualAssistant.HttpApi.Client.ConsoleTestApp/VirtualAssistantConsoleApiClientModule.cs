using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Rich.VirtualAssistant;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(VirtualAssistantHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class VirtualAssistantConsoleApiClientModule : AbpModule
{

}
