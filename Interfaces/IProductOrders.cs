using tienda_electronica_api_server.DTO;

namespace tienda_electronica_api_server.Interfaces;

public interface IProductOrders
{
    Task<IEnumerable<ProductOrders>> GetProductOrders();
    Task<String> CreateProductOrder(ProductOrders order);
    Task<String> UpdateProductOrder(DTO.ProductOrders update);
}