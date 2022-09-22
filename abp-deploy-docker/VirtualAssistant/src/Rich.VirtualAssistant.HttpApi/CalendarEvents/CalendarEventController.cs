using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rich.VirtualAssistant.CalendarEvent;

namespace Rich.VirtualAssistant.calendarEvents;

[Area(VirtualAssistantRemoteServiceConsts.ModuleName)]
[ControllerName("CalendarEvent")]
[Route("api/va/event")]
public class CalendarEventController : VirtualAssistantController
{
    private readonly ICalendarEventAppService _calendarEventAppService;

    public CalendarEventController(ICalendarEventAppService calendarEventAppService)
    {
        _calendarEventAppService = calendarEventAppService;
    }

    [Route("GetAll")]
    [HttpGet]
    public Task<List<EventDto>> GetAll()
    {
        return _calendarEventAppService.GetAll();
    }

    [HttpGet]
    [Route("get/{id}")]
    public Task<EventDto> GetAsync(Guid id)
    {
        return _calendarEventAppService.GetAsync(id);
    }
    
    // [HttpGet]
    // public Task<IEnumerable<EventDto>> GetListAsync(Guid calendarGuid)
    // {
    //     return _calendarEventAppService.GetListAsync(calendarGuid);
    // }
    
    [HttpPost]
    public Task<EventDto> CreateAsync(CreateDto input)
    {
        return _calendarEventAppService.CreateAsync(input);
    }
    
    [HttpPut]
    public Task<EventDto> UpdateAsync(Guid id, string name, string remark)
    {
        return _calendarEventAppService.UpdateAsync(id, name, remark);
    }
    
    [HttpDelete]
    public Task DeleteAsync(Guid id)
    {
       return _calendarEventAppService.DeleteAsync(id);
    }
}