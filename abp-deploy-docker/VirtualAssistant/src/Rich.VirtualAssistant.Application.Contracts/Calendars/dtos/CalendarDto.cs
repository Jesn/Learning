using System;
using JetBrains.Annotations;

namespace Rich.VirtualAssistant.Calendars;

[Serializable]
public class CalendarDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
}