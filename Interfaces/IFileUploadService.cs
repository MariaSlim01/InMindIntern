using Microsoft.AspNetCore.Mvc;
using WebApplication1.Helpers;

namespace WebApplication1.Interfaces;

public interface IFileUploadService
{

   public  Task<IActionResult> UploadFile(IFormFile file);
   

}