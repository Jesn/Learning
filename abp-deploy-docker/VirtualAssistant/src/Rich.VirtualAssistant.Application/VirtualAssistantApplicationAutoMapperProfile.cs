using AutoMapper;
using Rich.VirtualAssistant.Calendars;
using Rich.VirtualAssistant.Todos;

namespace Rich.VirtualAssistant;

public class VirtualAssistantApplicationAutoMapperProfile : Profile
{
    public VirtualAssistantApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Calendar, CalendarDto>();
        CreateMap<Todo, TodoDto>();
        
        
    }
}