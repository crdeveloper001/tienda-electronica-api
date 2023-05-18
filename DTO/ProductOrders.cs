using System.Diagnostics.CodeAnalysis;

namespace tienda_electronica_api_server.DTO;

public class ProductOrders
{
    [NotNull]
    public string? _id { get; set; }
    [NotNull]
    public UserAccounts? client { get; set; }
    [NotNull]
    public List<Products>? products { get; set; }
    [NotNull]
    public double productOrderTotalPrice { get; set; }
    
}