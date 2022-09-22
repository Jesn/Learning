using Rich.VirtualAssistant.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Rich.VirtualAssistant;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(VirtualAssistantEntityFrameworkCoreTestModule)
    )]
public class VirtualAssistantDomainTestModule : AbpModule
{

}
