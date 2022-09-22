using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Rich.VirtualAssistant.Calendars;

public class CalendarAppService_Tests : VirtualAssistantApplicationTestBase
{
    private readonly ICalendarAppService _calendarAppService;

    public CalendarAppService_Tests()
    {
        _calendarAppService = GetRequiredService<ICalendarAppService>();
    }

    [Fact]
    public async Task CreateAsync()
    {
        var calendarDto = await _calendarAppService.CreateAsync("生日");
        calendarDto.ShouldNotBeNull();
    }
}