using WorkerService.CleanArchitecture.Application.Common.Mappings;
using WorkerService.CleanArchitecture.Domain.Entities;

namespace WorkerService.CleanArchitecture.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public class TodoItemBriefDto : IMapFrom<TodoItem>
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}
