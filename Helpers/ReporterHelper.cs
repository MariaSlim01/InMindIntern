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
    public Reporter ChangeNameByID(List<Reporter> reporters, int id, string name)
    {
        try
        {
            Reporter reporter1 = reporters.Where(reporter => reporter.id == id).FirstOrDefault();
            if (reporter1 != null)
            {
                reporter1.name = name;
                return reporter1;
            }

            throw new ReporterNotFoundException();
        }
        catch (ReporterNotFoundException e)
        {
            Console.WriteLine("Reporter not found");
        }
        catch (Exception d)
        {
            Console.WriteLine(d.Message);
        }

        return null;
    }
    
    public Reporter DeleteByID(List<Reporter> reporters, int id)
    {
        try
        {
            Reporter reporter1 = reporters.Where(reporter => reporter.id == id).FirstOrDefault();
            if (reporter1 != null)
            {
                reporters.Remove(reporter1);
                return reporter1;
            }

            throw new ReporterNotFoundException();
        }
        catch (ReporterNotFoundException e)
        {
            Console.WriteLine("Reporter not found");
        }
        catch (Exception d)
        {
            Console.WriteLine(d.Message);
        }

        return null;
    }


}