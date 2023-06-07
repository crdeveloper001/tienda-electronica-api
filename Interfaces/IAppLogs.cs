using tienda_electronica_api_server.DTO;

namespace tienda_electronica_api_server.Interfaces;

public interface IAppLogs
{
    Task<IEnumerable<AppLogs>> GetAppLogs();
    Task<String> CreateAppLog(AppLogs log);
}