using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Rich.VirtualAssistant.MongoDB;

[ConnectionStringName(VirtualAssistantDbProperties.ConnectionStringName)]
public interface IVirtualAssistantMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
