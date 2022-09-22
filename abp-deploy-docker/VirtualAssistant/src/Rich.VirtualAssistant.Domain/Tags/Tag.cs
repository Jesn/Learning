using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Rich.VirtualAssistant.Tags;

public class Tag : CreationAuditedEntity<Guid>
{
    /// <summary>
    /// tag名称
    /// </summary>
    public string Name { get; private set; }

    protected Tag()
    {
    }

    public Tag(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}