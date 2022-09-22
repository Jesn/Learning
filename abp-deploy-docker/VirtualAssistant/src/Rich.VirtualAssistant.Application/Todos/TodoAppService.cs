using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Rich.VirtualAssistant.Events;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace Rich.VirtualAssistant.Todos;

[Authorize]
public class TodoAppService : VirtualAssistantAppService, ITodoAppService
{
    private readonly TodoManager _todoManager;
    private readonly IRepository<Todo> _todoRepository;

    public TodoAppService(TodoManager todoManager, IRepository<Todo> todoRepository)
    {
        _todoManager = todoManager;
        _todoRepository = todoRepository;
    }
    
    /// <summary>
    /// 获取用户所有待办事项
    /// </summary>
    /// <returns></returns>
    public async Task<List<TodoDto>> GetListAsync()
    {
        var userId = CurrentUser.GetId();
        var list = await _todoRepository.GetListAsync(x => x.CreatorId == userId);
        return ObjectMapper.Map<List<Todo>, List<TodoDto>>(list);
    }

    /// <summary>
    /// 获取当前月份的所有代办事项
    /// </summary>
    /// <param name="month"></param>
    /// <returns></returns>
    public async Task<List<TodoDto>> GetListAsyncByMonth(int month)
    {
        var userId = CurrentUser.GetId();
        var year = DateTime.Now.Year;

        var list = await _todoRepository.GetListAsync(x =>
            x.CreatorId == userId && x.CreationTime.Year == year && x.CreationTime.Month == month);

        return ObjectMapper.Map<List<Todo>, List<TodoDto>>(list);
    }

    /// <summary>
    /// 获取指定月份的所有代办事项
    /// </summary>
    /// <param name="month1"></param>
    /// <param name="month2"></param>
    /// <returns></returns>
    public async Task<List<TodoDto>> GetListAsyncByMonths(int month1, int month2)
    {
        var userId = CurrentUser.GetId();
        var year = DateTime.Now.Year;

        var list = await _todoRepository.GetListAsync(x =>
            x.CreatorId == userId && x.CreationTime.Year == year &&
            (x.CreationTime.Month == month1 || x.CreationTime.Month == month2));

        return ObjectMapper.Map<List<Todo>, List<TodoDto>>(list);
    }


    /// <summary>
    /// 创建代办事项
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<TodoEto> CreateAsync(CreateTodoDto input)
    {
        var userId = CurrentUser.GetId();
        // 创建todo
        var newTodo = await _todoManager.CreateAsync(userId, input.Name, input.StartTime, input.EndTime, input.Remark,
            input.Tags);
        return newTodo;
    }

    /// <summary>
    /// 更新待办事项
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<TodoDto> UpdateAsync(Guid id, UpdateTodoDto input)
    {
        var todo = await _todoManager.GetAsync(id);

        todo.SetName(Check.NotNullOrWhiteSpace(input.Name, nameof(input.Name)));
        todo.SetRemark(input.Remark);
        if (input.StartTime != null && input.EndTime != null)
        {
            todo.SetTime(input.StartTime.Value, input.EndTime.Value);
        }

        await _todoRepository.UpdateAsync(todo);
        return ObjectMapper.Map<Todo, TodoDto>(todo);
    }

    /// <summary>
    /// 更新代办事项任务状态
    /// </summary>
    /// <param name="id"></param>
    /// <param name="status"></param>
    /// <returns></returns>
    public async Task<TodoDto> UpdateStatusAsync(Guid id, CallendarEventStatus status)
    {
        var todo = await _todoManager.GetAsync(id);
        todo.SetStatus(status);
        await _todoRepository.UpdateAsync(todo);
        return ObjectMapper.Map<Todo, TodoDto>(todo);
    }
}