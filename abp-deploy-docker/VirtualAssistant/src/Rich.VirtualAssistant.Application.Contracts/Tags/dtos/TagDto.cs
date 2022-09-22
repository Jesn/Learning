using System;
using Volo.Abp.Application.Dtos;

namespace Rich.VirtualAssistant.Tags;

public class TagDto : EntityDto<Guid>
{
    public string Name { get; set; }
}