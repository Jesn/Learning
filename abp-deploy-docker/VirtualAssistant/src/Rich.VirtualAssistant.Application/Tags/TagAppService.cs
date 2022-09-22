using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Rich.VirtualAssistant.Tags;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace Rich.VirtualAssistant.tags;

[Authorize]
public class TagAppService : VirtualAssistantAppService, ITagAppService
{
    private IRepository<Tag> _tagRepository { get; }

    public TagAppService(IRepository<Tag> tagRepository)
    {
        _tagRepository = tagRepository;
    }

    /// <summary>
    /// 获取当前用户下的所有tag
    /// </summary>
    /// <returns></returns>
    public async Task<List<TagDto>> GetListAsync()
    {
        var tags = await _tagRepository.GetListAsync(x => x.CreatorId == CurrentUser.GetId());
        return ObjectMapper.Map<List<Tag>, List<TagDto>>(tags);
    }
}