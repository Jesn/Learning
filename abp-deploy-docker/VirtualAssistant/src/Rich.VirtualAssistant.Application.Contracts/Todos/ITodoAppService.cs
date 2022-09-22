using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rich.VirtualAssistant.Events;
using Volo.Abp.Application.Services;

namespace Rich.VirtualAssistant.Todos;

public interface ITodoAppService : IApplicationService
{
    /// <summary>
    /// 获取用户所有待办事项
    /// </summary>
    /// <returns></returns>
    Task<List<TodoDto>> GetListAsync();

    /// <summary>
    /// 获取当前月份的所有代办事项
    /// </summary>
    /// <param name="month"></param>
    /// <returns></returns>
    Task<List<TodoDto>> GetListAsyncByMonth(int month);

    /// <summary>
    /// 获取指定月份的所有代办事项
    /// </summary>
    /// <param name="month1"></param>
    /// <param name="month2"></param>
    /// <returns></returns>
    Task<List<TodoDto>> GetListAsyncByMonths(int month1, int month2);

    /// <summary>
    /// 创建代办事项
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<TodoEto> CreateAsync(CreateTodoDto input);

    /// <summary>
    /// 更新待办事项
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<TodoDto> UpdateAsync(Guid id, UpdateTodoDto input);

    /// <summary>
    /// 更新代办事项任务状态
    /// </summary>
    /// <param name="id"></param>
    /// <param name="status"></param>
    /// <returns></returns>
    Task<TodoDto> UpdateStatusAsync(Guid id, CallendarEventStatus status);
}