using System;
using System.ComponentModel.DataAnnotations;

namespace Rich.VirtualAssistant.Todos;

public class UpdateTodoDto
{
    [Required]
    public  string Name { get; set; }
    public  DateTime? StartTime { get; set; }
    public  DateTime? EndTime { get; set; }
    public  string Remark { get; set; }
}