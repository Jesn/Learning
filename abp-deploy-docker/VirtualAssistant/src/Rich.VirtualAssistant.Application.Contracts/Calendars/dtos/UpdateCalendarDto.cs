using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace Rich.VirtualAssistant.Calendars;

public class UpdateCalendarDto
{
    [Required]
    public  string Name { get; set; }
    [Required]
    public  string Color { get; set; }
    
}