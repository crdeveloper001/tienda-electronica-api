using MongoDB.Driver;
using tienda_electronica_api_server.DTO;
using tienda_electronica_api_server.Interfaces;

namespace tienda_electronica_api_server.Services;

public class ProductsOrdersService : IProductOrders
{
    private readonly IMongoCollection<ProductOrders> _serviceProvider;

    public ProductsOrdersService(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("TiendaElectronicaDBCloud");
        _serviceProvider = database.GetCollection<ProductOrders>("CustomersOrders");
    }
    public async Task<IEnumerable<ProductOrders>> GetProductOrders()
    {
        var orders = await _serviceProvider.FindAsync(x => true);
        return orders.ToList();
    }

    public async Task<String> CreateProductOrder(ProductOrders order)
    {
        await _serviceProvider.InsertOneAsync(order);
        return "Order created";
    }

    public async Task<String> UpdateProductOrder(ProductOrders update)
    {
        await _serviceProvider.ReplaceOneAsync(x => x._id == update._id, update);
        return "Order updated";
    }
}