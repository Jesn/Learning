using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Rich.VirtualAssistant.MongoDB;

[ConnectionStringName(VirtualAssistantDbProperties.ConnectionStringName)]
public class VirtualAssistantMongoDbContext : AbpMongoDbContext, IVirtualAssistantMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureVirtualAssistant();
    }
}
