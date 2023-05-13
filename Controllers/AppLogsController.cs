using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tienda_electronica_api_server.DTO;
using tienda_electronica_api_server.Services;

namespace tienda_electronica_api_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppLogsController : ControllerBase
    {
        private readonly AppLogsService _service;
        
        public AppLogsController(AppLogsService appLogsService)
        {
            this._service = appLogsService;
        }

        [HttpGet]
        public async Task<IEnumerable<AppLogs>> GetAllAppLogs()
        {
            return await _service.GetAppLogs();
            
        }

        [HttpPost]
        public async Task<string> PostAppLog(AppLogs appLog)
        {
            return await _service.CreateAppLog(appLog);
        }

    }
}
