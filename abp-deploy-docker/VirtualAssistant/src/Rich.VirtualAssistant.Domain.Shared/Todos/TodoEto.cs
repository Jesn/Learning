using System;
using System.Collections.Generic;

namespace Rich.VirtualAssistant.Todos;

public class TodoEto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public DateTime CreationTime { get; set; }
    public string Remark { get; set; }
    public IEnumerable<TodoTagEto> Tags { get; set; }
}

public class TodoTagEto
{
    public Guid TagId { get; set; }
    public string TagName { get; set; }
}