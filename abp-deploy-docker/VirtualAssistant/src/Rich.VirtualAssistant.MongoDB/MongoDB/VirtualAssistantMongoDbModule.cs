using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Rich.VirtualAssistant.MongoDB;

[DependsOn(
    typeof(VirtualAssistantDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class VirtualAssistantMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<VirtualAssistantMongoDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
        });
    }
}
