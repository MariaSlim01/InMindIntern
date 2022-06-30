using System.Collections.Immutable;
using System.Globalization;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Exceptions;
using WebApplication1.Helpers;
using WebApplication1.Interfaces;
using WebApplication1.Requests;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private IReporterHelper _repHelper;
    private IGetDateHelper _getDateHelper;
    private IFileUploadService _uploadService;

    public WeatherForecastController(IReporterHelper ireporterhelper, IGetDateHelper igetdatehelper,
        IFileUploadService iuploadservice)
    {
        _repHelper = ireporterhelper;
        _getDateHelper = igetdatehelper;
        _uploadService = iuploadservice;
    }

    public static List<Reporter> Reporters = new List<Reporter>()
    {
        new Reporter()
        {
            name = "Maria",
            id = 1,
            email = "mariaslim2001@gmail.com"
        },
        new Reporter()
        {
            name = "Serge",
            id = 2,
            email = "serge@gmail.com"
        }
    };

    [HttpGet("GetRep")]
    public List<Reporter> GetReporter()
    {
        return Reporters;
    }

    [HttpGet("/{id}")]
    public Reporter GetReporterByID([FromRoute] int id)
    {
        return _repHelper.GetReporterByID(Reporters, id);

    }


    [HttpPost("AddReporter")]
    public Reporter AddReporter([FromBody] AddReporterRequest request)
    {
        Reporter a = new Reporter()
        {
            name = request.Name,
            id = request.id,
            email = request.email
        };
        Reporters.Add(a);
        return a;
    }

    [HttpGet("/FindByName")]

    public List<Reporter> GetPart([FromQuery] string value)
    {
        return _repHelper.GetReportersByName(Reporters, value);
    }

    [HttpGet("GetDateByLanguage")]
    public string GetDateFromLang([FromHeader] string lang)
    {
        return _getDateHelper.GetDate(lang);

    }

    [HttpPost("ChangeReporterName")]
    public Reporter ChangeReporter([FromBody] EditReporterNameByIDRequest req)
    {
        return _repHelper.ChangeNameByID(Reporters, req.id, req.Name);
    }

    [HttpDelete("Delete")]
    public Reporter DeleteById([FromHeader] int id)
    {
        return _repHelper.DeleteByID(Reporters, id);

    }
    //[HttpPost("UploadFile")]
    //public bool UploadFile(IFormFile file)
    //{
    //    return _uploadService.UploadFile(file);

    // }
    [HttpPost]
    public Task<IActionResult> Post(IFormFile file)
    {
        return _uploadService.UploadFile(file);
    }
}
