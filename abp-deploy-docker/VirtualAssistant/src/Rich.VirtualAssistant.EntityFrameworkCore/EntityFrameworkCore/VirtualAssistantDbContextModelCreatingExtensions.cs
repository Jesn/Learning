using Microsoft.EntityFrameworkCore;
using Rich.VirtualAssistant.Calendars;
using Rich.VirtualAssistant.Tags;
using Rich.VirtualAssistant.Todos;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Rich.VirtualAssistant.EntityFrameworkCore;

public static class VirtualAssistantDbContextModelCreatingExtensions
{
    public static void ConfigureVirtualAssistant(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(VirtualAssistantDbProperties.DbTablePrefix + "Questions", VirtualAssistantDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */


        builder.Entity<Calendar>(b =>
        {
            b.ToTable("Calendars");
            b.ConfigureByConvention();
            b.Property(q => q.Name).IsRequired().HasMaxLength(20);
            b.Property(q => q.Color).IsRequired().HasDefaultValue("#0099ff").HasMaxLength(8);
        });

        // builder.Entity<CalendarEvent>(b =>
        // {
        //     b.ToTable("CalendarEvents");
        //     b.ConfigureByConvention(); // ascii_general_ci
        //     b.Property(q => q.CalendarGuid).IsRequired().HasColumnType("char").HasMaxLength(36);
        //     b.Property(q => q.Name).IsRequired().HasMaxLength(20);
        //     b.Property(q => q.Remark).HasMaxLength(100);
        // });

        builder.Entity<Todo>(b =>
        {
            b.ToTable("Todos");
            b.ConfigureByConvention();
            b.Property(q => q.Name).IsRequired().HasMaxLength(50);
            b.Property(q => q.Remark).HasMaxLength(100);
        });

        builder.Entity<Tag>(b =>
        {
            b.ToTable("Tags");
            b.ConfigureByConvention();
            b.Property(q => q.Name).IsRequired().HasMaxLength(10);
        });

        builder.Entity<TodoTag>(b =>
        {
            b.ToTable("TodoTags");
            b.ConfigureByConvention();
            b.Property(q => q.TagGuid).IsRequired().HasColumnType("char").HasMaxLength(36);
            b.Property(q => q.TodoGuid).IsRequired().HasColumnType("char").HasMaxLength(36);

            b.HasKey(x => new { x.TodoGuid, x.TagGuid });
            b.ApplyObjectExtensionMappings();
        });
    }
}