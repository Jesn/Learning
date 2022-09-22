using Microsoft.EntityFrameworkCore;
using Rich.VirtualAssistant.Calendars;
using Rich.VirtualAssistant.Tags;
using Rich.VirtualAssistant.Todos;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Rich.VirtualAssistant.EntityFrameworkCore;

[ConnectionStringName(VirtualAssistantDbProperties.ConnectionStringName)]
public interface IVirtualAssistantDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */

    DbSet<Calendar> Calendars { get; set; }
    DbSet<Todo> Todos { get; set; }
    DbSet<Tag> Tags { get; set; }
    DbSet<TodoTag> TodoTags { get; set; }
}