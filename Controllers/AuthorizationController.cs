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
    public class AuthorizationController : ControllerBase
    {
        private readonly UserAccountsServices _services;

        public AuthorizationController(UserAccountsServices services)
        {
            _services = services;
        }

        [HttpPost]
        public Task<UserAccounts> PostAuthAccount([FromBody] Authorization credentials)
        {
            return _services.AuthorizeUserAccount(credentials);
        }
    }
}
