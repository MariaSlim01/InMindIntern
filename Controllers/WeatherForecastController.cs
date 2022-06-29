using System.Collections.Immutable;
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
    public IReporterHelper _repHelper; 
    public List<Reporter> Reporters; 
    
    public WeatherForecastController(IReporterHelper ireporterhelper)
    {
        _repHelper = ireporterhelper;
        Reporters = new List<Reporter>()
        {
            new Reporter()
            {
                name = "Maria",
                id=1
            }, new Reporter()
            {
                name = "Serge",
                id=2
            }
        };
    }
    
    
    [HttpGet("GetRep")]
    public List<Reporter> GetReporter()
    {

        return Reporters;
    }
    
    [HttpGet("RepID/{id}")]
    public Reporter GetReporterByID([FromRoute] int id)
    {
        return _repHelper.GetReporterByID(Reporters,id);

    }


    [HttpPost("AddReporter")]
    public Reporter AddReporter([FromBody] AddReporterRequest request)
    {
        Reporter a = new Reporter()
        {
            name = request.Name,
            id=request.id
        };
        Reporters.Add(a);
        return a;
    }
    
    /*[HttpPost("DeleteReporter")]
    public Reporter DeleteReporter([FromBody] DeleteReporterRequest request)
    {
        for (int i = 0; i < Reporters.Count; i++)
        {
            if Reporters.
        }
    }*/
   
   
}
