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

    public List<Reporter> GetReportersByName(List<Reporter> reporters, string name)
    {
        List<Reporter> reporters1 = reporters. Where(reporter => reporter.name.Contains(name)).ToList();
        return reporters1;
    }


}