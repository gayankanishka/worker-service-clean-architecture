using WorkerService.CleanArchitecture.Domain.Models;

namespace WorkerService.CleanArchitecture.Domain.Messages;

public class SendEmailMessage
{
    public Guid MessageId { get; set; }
    public DateTime CreationDate { get; set; }
    public string Source { get; set; }
    public EmailPayload EmailPayload { get; set; }
}