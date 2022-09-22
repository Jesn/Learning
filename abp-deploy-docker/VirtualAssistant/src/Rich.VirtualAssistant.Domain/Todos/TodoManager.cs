using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Rich.VirtualAssistant.Tags;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace Rich.VirtualAssistant.Todos;

public class TodoManager : DomainService
{
    protected IRepository<Todo> _todoRepository { get; }
    protected IRepository<Tag> _tagRepository { get; }
    protected IRepository<TodoTag> _todoTagRepository { get; }

    public TodoManager(IRepository<Todo, Guid> todoRepository,
        IRepository<Tag> tagRepository,
        IRepository<TodoTag> todoTagRepository)
    {
        _todoRepository = todoRepository;
        _tagRepository = tagRepository;
        _todoTagRepository = todoTagRepository;
    }

    public async Task<Todo> GetAsync(Guid id)
    {
        var todo = await _todoRepository.GetAsync(x => x.Id == id);
        return todo;
    }


    /// <summary>
    /// 创建Todo
    /// </summary>
    [UnitOfWork]
    public virtual async Task<TodoEto> CreateAsync(
        [NotNull] Guid userId,
        [NotNull] string name,
        [CanBeNull] DateTime? startTime,
        [CanBeNull] DateTime? endTime,
        [CanBeNull] string remark,
        [CanBeNull] List<string> tags = null)
    {
        var todo = new Todo(GuidGenerator.Create(), name, userId);
        if (startTime != null && endTime != null)
            todo.SetTime(startTime.Value, endTime.Value);
        if (!remark.IsNullOrWhiteSpace())
            todo.SetRemark(remark);

        var newTodoTags = new List<TodoTag>();
        var list_tag = new List<Tag>();
        if (tags != null)
        {
            list_tag = await _tagRepository.GetListAsync(x => x.CreatorId == userId && tags.Contains(x.Name));
            var newTags = new List<Tag>();
            foreach (var item in tags)
            {
                var tag = list_tag.FirstOrDefault(x => x.Name == item);
                if (tag is null)
                {
                    var newTag = new Tag(GuidGenerator.Create(), item);
                    newTags.Add(newTag);
                    newTodoTags.Add(new TodoTag(todo.Id, newTag.Id));
                }
                else
                {
                    newTodoTags.Add(new TodoTag(todo.Id, tag.Id));
                }
            }

            list_tag.AddRange(newTags);

            await _tagRepository.InsertManyAsync(newTags);
            await _todoTagRepository.InsertManyAsync(newTodoTags);
        }

        var newTodo = await _todoRepository.InsertAsync(todo);

        var todoEto = new TodoEto()
        {
            Id = newTodo.Id,
            Name = newTodo.Name,
            Remark = newTodo.Remark,
            CreationTime = newTodo.CreationTime,
            StartTime = newTodo.StartTime,
            EndTime = newTodo.EndTime,
            Tags = newTodoTags?.Select(x => new TodoTagEto()
            {
                TagId = x.TagGuid,
                TagName = list_tag.FirstOrDefault(t => t.Id == x.TagGuid).Name
            })
        };
        return todoEto;
    }
}