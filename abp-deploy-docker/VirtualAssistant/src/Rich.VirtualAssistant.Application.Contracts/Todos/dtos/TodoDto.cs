using System;
using Rich.VirtualAssistant.Events;
using Volo.Abp.Application.Dtos;

namespace Rich.VirtualAssistant.Todos;

[Serializable]
public class TodoDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime CreationTime { get; set; }
    public  CallendarEventStatus Status { get; set; }
    public string Remark { get; set; }
}