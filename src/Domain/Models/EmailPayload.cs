namespace WorkerService.CleanArchitecture.Domain.Models;

public class EmailPayload
{
    public string ToAddress { get; set; }
    public string ToUser { get; set; }
    public string FromAddress { get; set; }
    public string FromUser { get; set; }
    public IList<string> CCs { get; set; }
    public IList<string> BCcs { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}
