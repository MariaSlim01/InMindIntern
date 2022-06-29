using WebApplication1.Controllers;

namespace WebApplication1.Interfaces;

public interface IReporterHelper
{
        public Reporter GetReporterByID(List<Reporter> reporters, int id);
        public List<Reporter> GetReportersByName(List<Reporter> reporters, string name);
        public Reporter ChangeNameByID(List<Reporter> reporters, int id, string name);
        public Reporter DeleteByID(List<Reporter> reporters, int id);


}