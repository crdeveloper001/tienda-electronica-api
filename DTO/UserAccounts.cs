using System.Diagnostics.CodeAnalysis;

namespace tienda_electronica_api_server.DTO;

public class UserAccounts
{
    public long _id { get; set; }
    [NotNull]
    public string? clientUriProfile { get; set; }      
    [NotNull]
    public string? clientName { get; set; }
    [NotNull]
    public string? clientLastName { get; set; }
    [NotNull]
    public int clientPhone { get; set; }
    [NotNull]
    public string? clientEmail { get; set; }
    [NotNull]
    public string? clientDirection { get; set; }
    [NotNull]
    public string? clientUsername { get; set; }
    [NotNull]
    public string? clientPassword { get; set; }
    [NotNull]
    public string? clientRoleType { get; set; }
    public bool? UserAccountActive { get; set; }
    public string? JWT { get; set; }
    
}