using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Rich.VirtualAssistant.EntityFrameworkCore;

[DependsOn(
    typeof(VirtualAssistantDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class VirtualAssistantEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<VirtualAssistantDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
            options.AddDefaultRepositories(includeAllEntities: true);
        });
    }
}