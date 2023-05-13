using MongoDB.Driver;
using tienda_electronica_api_server.DTO;
using tienda_electronica_api_server.Interfaces;

namespace tienda_electronica_api_server.Services;

public class ProductsService : IProducts
{
    private readonly IMongoCollection<Products> _serviceProvider;

    public ProductsService(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("TiendaElectronicaDBCloud");
        _serviceProvider = database.GetCollection<Products>("Products");
    }

    public async Task<IEnumerable<Products>> GetProductos()
    {
        var productsList = await _serviceProvider.FindAsync(x => true);
        return productsList.ToList();
    }

    public async Task<String> CreateProduct(Products product)
    {
        await _serviceProvider.InsertOneAsync(product);
        return "Product created in the app";
    }

    public async Task<String> DeleteProduct(string _id)
    {
        await _serviceProvider.DeleteOneAsync(x => x._id == _id);
        return "Product deleted";
    }

    public async Task<String> UpdateProduct(Products update)
    {
        await _serviceProvider.ReplaceOneAsync(x => x._id == update._id, update);
        return "Product Updated";
    }

    public async Task<IEnumerable<Products>> SearchProduct(string name)
    {
        var productInformation = await _serviceProvider.FindAsync(x => x.productName == name);

        return productInformation.ToList();
    }
}