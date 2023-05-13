using System.Diagnostics.CodeAnalysis;

namespace tienda_electronica_api_server.DTO;

public class AppLogs
{
    [NotNull]
    public string _id { get; set; }
    [NotNull]
    public string eventType { get; set; }
    [NotNull]
    public string eventDescription { get; set; }
    [NotNull]
    public DateTime eventDate { get; set; }
}