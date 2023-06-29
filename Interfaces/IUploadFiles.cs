namespace tienda_electronica_api_server.Interfaces;

public interface IUploadFiles
{
    string UploadProfileImage(IFormFile file);
    string UploadProductImage(IFormFile file);
    Task<List<string>> GetAllImagesList();
    Task<string> DeleteImageSelect(string imageName);
}