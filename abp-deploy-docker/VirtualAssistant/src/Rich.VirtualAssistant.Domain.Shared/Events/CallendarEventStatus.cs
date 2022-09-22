using System.ComponentModel;

namespace Rich.VirtualAssistant.Events;

/// <summary>
/// 日历事件状态
/// </summary>
public enum CallendarEventStatus
{
    /// <summary>
    /// 待处理
    /// </summary>
    [Description("待处理")] Pending = 0,

    /// <summary>
    /// 进行中
    /// </summary>
    [Description("进行中")] Processing = 2,
    
    /// <summary>
    /// 已逾期
    /// </summary>
    [Description("已逾期")] Overdue = 4,

    /// <summary>
    /// 已完成
    /// </summary>
    [Description("已完成")] Finished = 6
}