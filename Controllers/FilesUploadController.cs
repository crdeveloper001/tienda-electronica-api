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
        public Task<Task<string>> PostUpload(IFormFile? image)
        {
            Task<string> response = _service.UploadImage(image);
            return Task.FromResult(response);
        }

        [HttpGet]
        public Task<List<string>> GetAllImages()
        {
            return _service.GetAllImagesList();
        }

        [HttpDelete("{imageName}")]
        public Task<string> DeleteImage(string imageName)
        {
            return _service.DeleteImageSelect(imageName);
        }
    }
}
