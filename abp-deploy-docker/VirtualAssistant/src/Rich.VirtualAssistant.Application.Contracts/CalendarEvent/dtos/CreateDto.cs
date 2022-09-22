using System;

namespace Rich.VirtualAssistant.CalendarEvent;

public class CreateDto
{
    public Guid CalendarGuid { get; set; }
    public string Name { get; set; }
    public string Remark { get; set; }
}