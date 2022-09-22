using System;
using System.Collections.Generic;

namespace Rich.VirtualAssistant.Todos;

public class CreateTodoDto
{
    public string Name { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public  List<string> Tags { get; set; }
    public  string Remark { get; set; }
}