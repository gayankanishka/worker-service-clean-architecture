using WorkerService.CleanArchitecture.Domain.Models;

namespace WorkerService.CleanArchitecture.Application.Common.Interfaces;

public interface ISendgridService
{
    Task<bool> SendMailAsync(EmailPayload payload, CancellationToken cancellationToken = new ());
}