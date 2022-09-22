using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rich.VirtualAssistant.Events;

namespace Rich.VirtualAssistant.Todos;

public class TodoController : VirtualAssistantController, ITodoAppService
{
    private readonly ITodoAppService _todoAppService;

    public TodoController(ITodoAppService todoAppService)
    {
        _todoAppService = todoAppService;
    }


    public Task<List<TodoDto>> GetListAsync()
    {
        return _todoAppService.GetListAsync();
    }

    public Task<List<TodoDto>> GetListAsyncByMonth(int month)
    {
        return _todoAppService.GetListAsyncByMonth(month);
    }

    public Task<List<TodoDto>> GetListAsyncByMonths(int month1, int month2)
    {
        return _todoAppService.GetListAsyncByMonths(month1, month2);
    }

    public Task<TodoEto> CreateAsync(CreateTodoDto input)
    {
        return _todoAppService.CreateAsync(input);
    }

    public Task<TodoDto> UpdateAsync(Guid id, UpdateTodoDto input)
    {
        return _todoAppService.UpdateAsync(id, input);
    }

    public Task<TodoDto> UpdateStatusAsync(Guid id, CallendarEventStatus status)
    {
        return _todoAppService.UpdateStatusAsync(id, status);
    }
}