using System.Diagnostics.CodeAnalysis;

namespace tienda_electronica_api_server.DTO;

public class Products
{
    
    public string _id { get; set; }
    [NotNull]
    public string productName { get; set; }
    [NotNull]
    public string productDetails { get; set; }
    [NotNull]
    public string productType { get; set; }
    [NotNull]
    public string productImageUrl { get; set; }
    [NotNull]
    public int productPrice { get; set; }
    [NotNull]
    public int productStock { get; set; }
    
}