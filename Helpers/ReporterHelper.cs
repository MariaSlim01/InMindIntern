using WebApplication1.Controllers;
using WebApplication1.Exceptions;
using WebApplication1.Interfaces;

namespace WebApplication1.Helpers;

public class ReporterHelper:IReporterHelper
{
    public Reporter GetReporterByID(List<Reporter> reporters, int id)
    {
        try
        {
            var reporter = reporters. Where(reporter => reporter.id == id).FirstOrDefault();

            if (reporter == null)
            {
                throw new ReporterNotFoundException();
            }

            return reporter;
        }
        catch (ReporterNotFoundException e)
        {
            Console.Write("This reporter was not found");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw e;
        }

        return null;

    }

}