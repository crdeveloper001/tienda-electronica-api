using tienda_electronica_api_server.DTO;

namespace tienda_electronica_api_server.Interfaces;

public interface IProducts
{
    Task<IEnumerable<Products>> GetProductos();
    Task<String> CreateProduct(Products product);
    Task<String> DeleteProduct(string _id);
    Task<String> UpdateProduct(Products update);
    Task<IEnumerable<Products>> SearchProduct(string name);
}