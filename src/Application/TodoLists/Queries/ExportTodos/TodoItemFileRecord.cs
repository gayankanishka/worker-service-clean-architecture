using WorkerService.CleanArchitecture.Application.Common.Mappings;
using WorkerService.CleanArchitecture.Domain.Entities;

namespace WorkerService.CleanArchitecture.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
