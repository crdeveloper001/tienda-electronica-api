
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
    
    public string UploadImage(IFormFile? file)
    {
        try
        {
          
            if (file != null && file.Length > 0)
            {
                var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Resources","Images");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                file.CopyTo(new FileStream(filePath, FileMode.Create));
        
                // You can save the file path to a database or perform other operations here

                return "Sucess";
            }
           


        }
        catch (Exception e)
        {
            return e.Message;
        }


        return "no paso nada";
    }
}