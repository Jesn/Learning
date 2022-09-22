using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Rich.VirtualAssistant.Reminds;

/// <summary>
/// 提醒-日程
/// </summary>
public class Remind : CreationAuditedEntity<Guid>
{
    /// <summary>
    /// 日历GUID
    /// </summary>
    public virtual Guid? CalendarGuid { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public virtual string Remark { get; set; }

    /// <summary>
    /// 提醒日期
    /// </summary>
    public virtual DateTime RemindTime { get; set; }

    /// <summary>
    /// 重复类型
    /// </summary>
    public virtual RemindRepeatTypeEnum RepeatType { get; set; }
}