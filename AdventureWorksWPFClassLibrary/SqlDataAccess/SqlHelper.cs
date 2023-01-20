using System.Configuration;

namespace AdventureWorksWPFClassLibrary.SqlDataAccess
{
    public class SqlHelper
    {
        public static string CnnVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
