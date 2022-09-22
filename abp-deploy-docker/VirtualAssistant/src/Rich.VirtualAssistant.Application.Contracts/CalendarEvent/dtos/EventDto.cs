using System;

namespace Rich.VirtualAssistant.CalendarEvent;

/// <summary>
/// Calendar Event DTO
/// </summary>
[Serializable]
public class EventDto
{
    public virtual Guid Id { get; set; }
    public virtual Guid CalendarGuid { get; set; }
    public virtual string Name { get; set; }
    public virtual string Remark { get; set; }
    public virtual DateTime CreationTime { get; set; }
}