using MongoDB.Driver;
using tienda_electronica_api_server.DTO;

namespace tienda_electronica_api_server.Interfaces;

public interface IUserAccounts
{
    Task<IEnumerable<UserAccounts?>> GetUserAccounts();
    Task<String> CreateAccount(UserAccounts? account);
    Task<String> UpdateAccount(UserAccounts? update);
    Task<String> DeleteAccount(long _id);
    Task<IEnumerable<UserAccounts?>> SearchAccount(string name);
    //THIS METHOD WOULD BE THE AUTHORIZATION FOR BOTH APPS
    Task<UserAccounts> AuthorizeUserAccount(Authorization credentials);
}