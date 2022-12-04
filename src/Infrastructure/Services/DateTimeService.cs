using WorkerService.CleanArchitecture.Application.Common.Interfaces;

namespace WorkerService.CleanArchitecture.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}