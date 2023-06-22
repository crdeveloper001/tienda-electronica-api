
namespace tienda_electronica_api_server.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
public class UploadFiles
{
    private readonly IWebHostEnvironment _hostEnvironment;

    public UploadFiles(IWebHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }
    
    public async Task<string> UploadImage(IFormFile? file)
    {
        try
        {
          
            if (file != null && file.Length > 0)
            {
                var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Resources","ProfilesImages");
                string uniqueFileName = Path.GetRandomFileName() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }


                return filePath;
            }
            
        }
        catch (Exception e)
        {
            return e.Message;
        }


        return "no paso nada";
    }
}