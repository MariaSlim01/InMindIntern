using Microsoft.AspNetCore.Mvc;
using WebApplication1.Exceptions;
using WebApplication1.Interfaces;

namespace WebApplication1.Helpers;

public class FileUploadService : IFileUploadService
{
    IWebHostEnvironment _environment;

    public FileUploadService(IWebHostEnvironment env)
    {
        _environment = env;
    }

    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        try
        {
            if (file.Length <= 0)
                throw new FileNotUploadedException();
            //Strip out any path specifiers (ex: /../)
            var originalFileName = Path.GetFileName(file.FileName);

            //Create a unique file path
            var uniqueFileName = Path.GetRandomFileName();
            var uniqueFilePath = Path.Combine(_environment.WebRootPath, uniqueFileName);

            //Save the file to disk
            using (var stream = System.IO.File.Create(uniqueFilePath))
            {
                await file.CopyToAsync(stream);
            }
        }
        catch (FileNotUploadedException e)
        {
            Console.WriteLine(e.errorMessage);
        }
        catch (Exception d)
        {
            Console.WriteLine(d.Message);
        }

        return new OkResult();
    }
}