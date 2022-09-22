using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Rich.VirtualAssistant.Todos;

/// <summary>
/// Todo Tag
/// </summary>
public class TodoTag : CreationAuditedEntity
{
    public virtual Guid TodoGuid { get; protected set; }
    public virtual Guid TagGuid { get; protected set; }


    protected TodoTag()
    {
    }

    public TodoTag(Guid todoGuid, Guid tagGuid)
    {
        TodoGuid = todoGuid;
        TagGuid = tagGuid;
    }

    public override object[] GetKeys()
    {
        return new object[] { TodoGuid, TagGuid };
    }
}