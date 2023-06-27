using MongoDB.Driver;
using Newtonsoft.Json;
using tienda_electronica_api_server.DTO;
using tienda_electronica_api_server.Interfaces;
using tienda_electronica_api_server.Security;

namespace tienda_electronica_api_server.Services;
public class UserAccountsServices : IUserAccounts
{
    private readonly IMongoCollection<UserAccounts?> _serviceProvider;
    private jwt_TokenGenerator JWT_GENERATOR = new jwt_TokenGenerator();
    private UploadFiles _uploadFilesService = new UploadFiles();

    [JsonConstructor]
    public UserAccountsServices(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("TiendaElectronicaDBCloud");
        _serviceProvider = database.GetCollection<UserAccounts>("UserAccounts")!;
    }
    public async Task<IEnumerable<UserAccounts?>> GetUserAccounts()
    {
        var userAccounts = await _serviceProvider.FindAsync(x => true);
        return userAccounts.ToList();
    }

    public async Task<string> CreateAccount(UserAccounts? account)
    {
        account!.UserAccountActive = true;
        await _serviceProvider.InsertOneAsync(account);
        return "User Account Created! please login with the credential of: " + account.clientUsername;
        
    }

    public async Task<string> UpdateAccount(UserAccounts? update)
    {
        
        if (update?.UserAccountActive == true)
        {
            update.UserAccountActive = true;
            var result = await _serviceProvider.ReplaceOneAsync(x => x!._id == update._id, update);

        }
        if (update?.UserAccountActive == false)
        {
            update.UserAccountActive = false;
            var result = await _serviceProvider.ReplaceOneAsync(x => x!._id == update._id, update);

        }

        return "User account updated";
    }

    public async Task<string> DeleteAccount(long _id)
    {

        var result = await _serviceProvider.DeleteOneAsync(x => x!._id == _id);
        return "User Account deleted";
    }

    public async Task<IEnumerable<UserAccounts?>> SearchAccount(string name)
    {
        var accountInformation = await _serviceProvider.FindAsync(x => x!.clientName == name);

        return accountInformation.ToList();
    }
    /// <summary>
    /// ESTE METODO CONSULTA EN MONGO LAS CREDENCIALES Y EVALUA EL ROL DE USUARIO Y ESTADO DE CUENTA ACTIVA Y GENERA EL JWT
    /// NECESARIO PARA CONSUMIR LOS ENDPOINTS DEL SERVIDOR
    /// </summary>
    /// <param name="credentials"></param>
    /// <returns></returns>
    public Task<UserAccounts> AuthorizeUserAccount(Authorization credentials)
    {
        var result = _serviceProvider.Find(x =>
            x!.clientUsername == credentials.username && x.clientPassword == credentials.password).FirstOrDefault();

        if (result == null)
        {
            UserAccounts errorPayload = new UserAccounts();
            errorPayload.clientRoleType = "UNDEFINED";
            errorPayload.UserAccountActive = false;
            errorPayload.JWT = "USER NOT FOUND";
            return Task.FromResult(errorPayload);

        }
        if (result.clientRoleType.Equals("Client") || result.clientRoleType.Equals("Administrator"))
        {
            if (result.UserAccountActive != null && result.UserAccountActive.Equals(true))
            {
                result.JWT = JWT_GENERATOR.GenerateToken();
                return Task.FromResult(result);
            }
            result.UserAccountActive = false;
            result.JWT = "NO AUTHORIZED";
            return Task.FromResult(result);
        }

        return Task.FromResult<UserAccounts>(null!);

    }
}