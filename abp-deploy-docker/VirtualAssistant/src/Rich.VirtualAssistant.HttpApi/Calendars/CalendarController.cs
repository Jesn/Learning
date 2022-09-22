using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Rich.VirtualAssistant.Calendars;

[Route("api/calendar/")]
public class CalendarController : VirtualAssistantController, ICalendarAppService
{
    private readonly ICalendarAppService _calendarAppService;

    public CalendarController(ICalendarAppService calendarAppService)
    {
        _calendarAppService = calendarAppService;
    }

    [Route("all")]
    [HttpGet]
    public Task<List<CalendarDto>> GetListAsync()
    {
        return _calendarAppService.GetListAsync();
    }

    [HttpPost]
    [Route("create")]
    public Task<CalendarDto> CreateAsync(string name)
    {
        return _calendarAppService.CreateAsync(name);
    }

    [HttpPut]
    [Route("update")]
    public Task<CalendarDto> UpdateAsync(Guid id, UpdateCalendarDto input)
    {
        return _calendarAppService.UpdateAsync(id, input);
    }

    [HttpDelete]
    [Route("delete")]
    public Task DeleteAsync(Guid id)
    {
        return _calendarAppService.DeleteAsync(id);
    }
}