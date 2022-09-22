using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Rich.VirtualAssistant.Calendars;

public class Calendar : AuditedAggregateRoot<Guid>
{
    /// <summary>
    /// 日历名称
    /// </summary>
    public string Name { get; protected set; }

    /// <summary>
    /// 日历颜色
    /// </summary>
    public string Color { get; protected set; }

    /// <summary>
    /// 日历默认颜色
    /// </summary>
    private const string DefaultColor = "#0099FF";

    protected Calendar()
    {
    }

    public Calendar(Guid id, [NotNull] string name)
    {
        Id = id;
        Name = name;
        Color = DefaultColor;
    }

    /// <summary>
    /// 设置日历名称
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public virtual Calendar SetName([NotNull] string name)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        return this;
    }

    /// <summary>
    /// 设置日历显示颜色
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public virtual Calendar SetColor([NotNull] string color)
    {
        // Color 默认为RGB，并且统一转换为大写
        Color = Check.NotNullOrWhiteSpace(color, nameof(color)).ToUpper();
        return this;
    }
}