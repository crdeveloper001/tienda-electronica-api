namespace tienda_electronica_api_server.Interfaces;

public interface IUploadFiles
{
    Task<string> UploadProfileImage(IFormFile file);
    Task<string> UploadProductImage(IFormFile file);
    Task<List<string>> GetAllImagesList();
    Task<string> DeleteImageSelect(string imageName);
}