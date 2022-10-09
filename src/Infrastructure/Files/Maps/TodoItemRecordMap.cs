using System.Globalization;
using WorkerService.CleanArchitecture.Application.TodoLists.Queries.ExportTodos;
using CsvHelper.Configuration;

namespace WorkerService.CleanArchitecture.Infrastructure.Files.Maps;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
    }
}
