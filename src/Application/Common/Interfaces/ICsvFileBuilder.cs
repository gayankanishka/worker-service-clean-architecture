using WorkerService.CleanArchitecture.Application.TodoLists.Queries.ExportTodos;

namespace WorkerService.CleanArchitecture.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
