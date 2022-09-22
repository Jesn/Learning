using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Rich.VirtualAssistant.EntityFrameworkCore;

public class VirtualAssistantHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<VirtualAssistantHttpApiHostMigrationsDbContext>
{
    public VirtualAssistantHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<VirtualAssistantHttpApiHostMigrationsDbContext>()
            .UseMySql(configuration.GetConnectionString("VirtualAssistant"),ServerVersion.AutoDetect(configuration.GetConnectionString("VirtualAssistant")));

        return new VirtualAssistantHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
