using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tienda_electronica_api_server.Services;

namespace tienda_electronica_api_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesUploadController : ControllerBase
    {
        private readonly UploadFiles _service;

        public FilesUploadController(UploadFiles service)
        {
            _service = service;
        }
        
        [HttpPost,DisableRequestSizeLimit]
        public Task<string> PostUpload(IFormFile? file)
        {
            string response = _service.UploadImage(file);
            return Task.FromResult(response);
        }
    }
}
