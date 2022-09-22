using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Rich.VirtualAssistant.Tags;

public interface ITagAppService : IApplicationService
{
    /// <summary>
    /// 获取用户下所有标签
    /// </summary>
    /// <returns></returns>
    Task<List<TagDto>> GetListAsync();
}