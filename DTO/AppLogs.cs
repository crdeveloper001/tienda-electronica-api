using System.Diagnostics.CodeAnalysis;
using MongoDB.Bson;

namespace tienda_electronica_api_server.DTO;

public class AppLogs
{
    [NotNull]
    public ObjectId? _id { get; set; }
    [NotNull]
    public string? eventType { get; set; }
    [NotNull]
    public string? eventDescription { get; set; }
    [NotNull]
    public string? eventDate { get; set; }
}