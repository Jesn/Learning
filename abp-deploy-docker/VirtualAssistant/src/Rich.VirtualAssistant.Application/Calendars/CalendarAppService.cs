using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace Rich.VirtualAssistant.Calendars;

[Authorize]
public class CalendarAppService : VirtualAssistantAppService, ICalendarAppService
{
    private readonly IRepository<Calendar> _calendarRepository;

    public CalendarAppService(IRepository<Calendar> calendarRepository)
    {
        _calendarRepository = calendarRepository;
    }

    /// <summary>
    /// 获取用户的所欲日历
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<List<CalendarDto>> GetListAsync()
    {
        var userId = CurrentUser.GetId();
        var list_calendar = await _calendarRepository.GetListAsync(x => x.CreatorId == userId);
        return ObjectMapper.Map<List<Calendar>, List<CalendarDto>>(list_calendar);
    }

    /// <summary>
    /// 创建日历
    /// </summary>
    /// <param name="name"></param>
    public async Task<CalendarDto> CreateAsync(string name)
    {
        var calendar = new Calendar(GuidGenerator.Create(), name);
        var newCalendar = await _calendarRepository.InsertAsync(calendar);

        return ObjectMapper.Map<Calendar, CalendarDto>(newCalendar);
    }

    /// <summary>
    /// 更新日历
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<CalendarDto> UpdateAsync(Guid id, UpdateCalendarDto input)
    {
        var calendar = await _calendarRepository.GetAsync(x => x.Id == id);

        calendar.SetName(input.Name);
        calendar.SetColor(input.Color);
        
        await _calendarRepository.UpdateAsync(calendar);

        return ObjectMapper.Map<Calendar, CalendarDto>(calendar);
    }

    public  async Task DeleteAsync(Guid id)
    {
        Check.NotNull(id, nameof(id));
        var calendar = await _calendarRepository.GetAsync(x => x.Id == id);
        await _calendarRepository.DeleteAsync(calendar);
    }
}