using WorkerService.CleanArchitecture.Application.Common.Mappings;
using WorkerService.CleanArchitecture.Domain.Entities;

namespace WorkerService.CleanArchitecture.Application.Common.Models;

// Note: This is currently just used to demonstrate applying multiple IMapFrom attributes.
public class LookupDto : IMapFrom<TodoList>, IMapFrom<TodoItem>
{
    public int Id { get; set; }

    public string? Title { get; set; }
}
