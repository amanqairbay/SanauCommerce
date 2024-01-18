using Catalog.Application.Exceptions;
using Catalog.Core.Entities;
using Catalog.Core.Logging;
using Catalog.Core.Repositories;
using Catalog.Core.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Catalog.Infrastructure.Services;

/// <summary>
/// Represents a file servise.
/// </summary>
public class FileService : IFileService
{
    private readonly IWebHostEnvironment _env;

    public FileService(IWebHostEnvironment env)
    {
        _env = env ?? throw new ArgumentNullException(nameof(env));
    }

    /// <summary>
    /// Saves the file.
    /// </summary>
    /// <param name="formFile">File</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Tuple<bool, string> SaveImage(IFormFile file, string imageName)
    {
        try
        {
            var rootPath = _env.WebRootPath;
            var path = Path.Combine(rootPath, $"img{Path.DirectorySeparatorChar}product-card");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var fileExtension = Path.GetExtension(file.FileName);
            var allowedFileExtensions = new string[] { ".jpg", ".jpeg", ".png", ".wbep" };

            if (!allowedFileExtensions.Contains(fileExtension))
            {
                return new Tuple<bool, string>(false, "Upload Failure. Unsupported File Extension.");
            }

            var newFileName = FileNameGenerator(imageName, fileExtension);
            var fileWithPath = Path.Combine(path, newFileName);
            var stream = new FileStream(fileWithPath, FileMode.Create);
            file.CopyTo(stream);
            stream.Close();

            return new Tuple<bool, string>(true, newFileName);
        }
        catch (Exception ex)
        {
            return new Tuple<bool, string>(false, $"Upload Failure. Somethimg went wrong. {ex.Message}");
        }
    }

    private static string FileNameGenerator(string name, string extension)
    {
        var fileName = name.ToLower().Replace(" ", "-") + "-" 
                + DateTime.UtcNow.Year.ToString().Substring(3)
                + DateTime.UtcNow.Month.ToString() 
                + DateTime.UtcNow.Day.ToString() 
                + DateTime.UtcNow.Hour.ToString() 
                + DateTime.UtcNow.Minute.ToString()
                + DateTime.UtcNow.Second.ToString() 
                + extension;

        return fileName;
    }
}