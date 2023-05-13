using MongoDB.Driver;
using tienda_electronica_api_server.DTO;
using tienda_electronica_api_server.Interfaces;

namespace tienda_electronica_api_server.Services;

public class AppLogsService : IAppLogs
{
    private readonly IMongoCollection<AppLogs> _serviceProvider;
    
    public AppLogsService(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("TiendaElectronicaDBCloud");
        _serviceProvider = database.GetCollection<AppLogs>("AppLogs");
    }
    public async Task<IEnumerable<AppLogs>> GetAppLogs()
    {
        var appLogs = await _serviceProvider.FindAsync(x => true);
        return appLogs.ToList();
        
    }
    public async Task<String> CreateAppLog(AppLogs log)
    {
        await _serviceProvider.InsertOneAsync(log);

        return "New Event in the system of type: "+log.eventType;
    }
}