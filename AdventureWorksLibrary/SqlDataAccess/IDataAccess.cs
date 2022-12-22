using AdventureWorksLibrary.Models;

namespace AdventureWorksLibrary.SqlDataAccess
{
    public interface IDataAccess
    {
        ILoginModel Login(ILoginModel Login);
    }
}