using WorkerService.CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WorkerService.CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
