using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Rich.VirtualAssistant.EntityFrameworkCore;

public class VirtualAssistantHttpApiHostMigrationsDbContext : AbpDbContext<VirtualAssistantHttpApiHostMigrationsDbContext>
{
    public VirtualAssistantHttpApiHostMigrationsDbContext(DbContextOptions<VirtualAssistantHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureVirtualAssistant();
    }
}
