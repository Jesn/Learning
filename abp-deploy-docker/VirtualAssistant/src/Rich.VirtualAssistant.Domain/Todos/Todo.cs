using System;
using JetBrains.Annotations;
using Rich.VirtualAssistant.Events;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Rich.VirtualAssistant.Todos;

public class Todo : AuditedAggregateRoot<Guid>
{
    /// <summary>
    /// 待办事项名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 任务状态
    /// </summary>
    public CallendarEventStatus Status { get; protected set; }

    /// <summary>
    /// 开始时间
    /// </summary>
    public DateTime? StartTime { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    public DateTime? EndTime { get; set; }

    /// <summary>
    /// 设置备注
    /// </summary>
    public string Remark { get; protected set; }


    protected Todo()
    {
    }


    public Todo(Guid id, [NotNull] string name, [NotNull] Guid userId)
    {
        Id = id;
        Name = name;
        CreatorId = userId;
        StartTime = null;
        EndTime = null;
    }

    public Todo(Guid id, [NotNull] string name, [NotNull] Guid userId, [NotNull] DateTime startTime,
        [NotNull] DateTime endTime)
    {
        Id = id;
        Name = name;
        CreatorId = userId;
        StartTime = startTime;
        EndTime = endTime;
    }

    /// <summary>
    /// 设置名称
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Todo SetName([NotNull] string name)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        return this;
    }

    /// <summary>
    /// 更改状态
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public Todo SetStatus(CallendarEventStatus status)
    {
        Status = status;
        return this;
    }


    /// <summary>
    /// 设置备注
    /// </summary>
    /// <param name="remark"></param>
    /// <returns></returns>
    public Todo SetRemark(string remark)
    {
        Remark = remark;
        return this;
    }


    /// <summary>
    /// 设置任务时间
    /// </summary>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <returns></returns>
    public Todo SetTime([NotNull] DateTime startTime, [NotNull] DateTime endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
        return this;
    }
}