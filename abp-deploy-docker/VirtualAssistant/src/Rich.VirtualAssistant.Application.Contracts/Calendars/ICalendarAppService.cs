using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Rich.VirtualAssistant.Calendars;

public interface ICalendarAppService : IApplicationService
{
    /// <summary>
    /// 获取用户的所欲日历
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<List<CalendarDto>> GetListAsync();

    /// <summary>
    /// 创建日历
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<CalendarDto> CreateAsync(string name);

    /// <summary>
    /// 更新日历
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<CalendarDto> UpdateAsync(Guid id, UpdateCalendarDto input);

    Task DeleteAsync(Guid id);
}