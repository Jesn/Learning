using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Rich.VirtualAssistant.MongoDB;

public static class VirtualAssistantMongoDbContextExtensions
{
    public static void ConfigureVirtualAssistant(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
