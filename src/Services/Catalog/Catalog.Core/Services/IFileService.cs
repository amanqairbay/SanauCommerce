using Microsoft.AspNetCore.Http;

namespace Catalog.Core.Services;

public interface IFileService
{
    Tuple<bool, string> SaveImage(IFormFile formFile, string imageName);
}