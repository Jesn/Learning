using Microsoft.EntityFrameworkCore;
using Rich.VirtualAssistant.Calendars;
using Rich.VirtualAssistant.Tags;
using Rich.VirtualAssistant.Todos;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Rich.VirtualAssistant.EntityFrameworkCore;

[ConnectionStringName(VirtualAssistantDbProperties.ConnectionStringName)]
public class VirtualAssistantDbContext : AbpDbContext<VirtualAssistantDbContext>, IVirtualAssistantDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public VirtualAssistantDbContext(DbContextOptions<VirtualAssistantDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureVirtualAssistant();
    }

    public DbSet<Calendar> Calendars { get; set; }
    public DbSet<Todo> Todos { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TodoTag> TodoTags { get; set; }
}
