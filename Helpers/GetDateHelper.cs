using System.Globalization;
using WebApplication1.Exceptions;
using WebApplication1.Interfaces;

namespace WebApplication1.Helpers;

public class GetDateHelper : IGetDateHelper
{
    public string GetDate(string lang)
    {
        try
        {
            CultureInfo[] cinfo = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);
            List<string> names=new List<string>();
            foreach (var cinf in cinfo)
            {
                names.Add(cinf.Name); 
            }

            var check = names.Contains(lang);


            if (check==true)
            {
                CultureInfo a = new CultureInfo(lang);
                string us = DateTime.Now.ToString(a);
                return us;
            }

            throw new InvalidLanguageException();
        }
        catch (InvalidLanguageException e)
        {
            Console.WriteLine("Invalid input language");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return null;  
    }
}