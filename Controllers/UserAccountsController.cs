using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using tienda_electronica_api_server.DTO;
using tienda_electronica_api_server.Services;

namespace tienda_electronica_api_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountsController : ControllerBase
    {
        private readonly UserAccountsServices _service;

        public UserAccountsController(UserAccountsServices service)
        {
            this._service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<UserAccounts?>> GetUser()
        {
            return await _service.GetUserAccounts();
        }
        [HttpGet("{name}")]
        public async Task<IEnumerable<UserAccounts?>> GetOneAccount(string name)
        {
            return await _service.SearchAccount(name);
        }
        [HttpPost,DisableRequestSizeLimit]
        public async Task<string> PostUserAccount([FromBody] UserAccounts? user)
        {
            return await _service.CreateAccount(user);
        }
        [HttpPut]
        public async Task<string> PutUserAccount(UserAccounts? update)
        {
            return await _service.UpdateAccount(update);
        }
        [HttpDelete("{id}")]
        public async Task<string> DeleteUserAccount(long id)
        {
            return await _service.DeleteAccount(id);
        }
        
    }
}
