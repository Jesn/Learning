using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Rich.VirtualAssistant.CalendarEvent;

public interface ICalendarEventAppService : IApplicationService
{
    Task<List<EventDto>> GetAll();
    Task<EventDto> GetAsync(Guid id);

    Task<IEnumerable<EventDto>> GetListAsync(Guid calendarGuid);

    Task<EventDto> CreateAsync(CreateDto input);

    Task<EventDto> UpdateAsync(Guid id,string name, string remark);

    Task DeleteAsync(Guid id);
}