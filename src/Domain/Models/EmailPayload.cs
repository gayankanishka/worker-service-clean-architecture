namespace WorkerService.CleanArchitecture.Domain.Models;

public record EmailPayload(
    string ToAddress,
    string ToUser,
    string FromAddress,
    string FromUser,
    IList<string> CCs,
    IList<string> BCcs,
    string Subject,
    string Body);
