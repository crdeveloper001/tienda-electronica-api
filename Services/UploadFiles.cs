
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
    /// <summary>
    /// THIS METHOD UPLOAD A IMAGE INTO WWWROOT AND RETRIEVE THE FILE PATH OF THAT IMAGE
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
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
                // Retorna el nombre del folder en donde se guardo la imagen exactamente en el api y este se acomoda en el front para verlo
                string folderPath = filePath.Substring(_hostEnvironment.WebRootPath.Length).Replace('\\', '/');

                return folderPath;
            }
            
        }
        catch (Exception e)
        {
            return e.Message;
        }
        return "no paso nada";
    }

    public Task<List<string>> GetAllImagesList()
    {
        try
        {
            string imagesPath = Path.Combine(_hostEnvironment.WebRootPath, "Resources","ProfilesImages");
            string[] imageFiles = Directory.GetFiles(imagesPath);

            List<string> imagePaths = new List<string>();

            foreach (string imagePath in imageFiles)
            {
                string imageName = Path.GetFullPath(imagePath);
                imagePaths.Add(imageName);
            }
            return Task.FromResult(imagePaths);
        }
        catch (DirectoryNotFoundException error)
        {
            throw error;
        }
        
    }

    public Task<string> DeleteImageSelect(string imageName)
    {
        try
        {
            string imagePath = Path.Combine(_hostEnvironment.WebRootPath, "Resources","ProfilesImages", imageName);

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
                return Task.FromResult("Image deleted successfully");
            }

            return Task.FromResult("Image not found");
        }
        catch (Exception ex)
        {
            return Task.FromResult(ex.Message);
        }
    }
}