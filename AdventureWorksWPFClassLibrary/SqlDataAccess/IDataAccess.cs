using AdventureWorksWPFClassLibrary.Models;
using AdventureWorksWPFClassLibrary.Models.DropDowns;

namespace AdventureWorksWPFClassLibrary.SqlDataAccess
{
    public interface IDataAccess
    {
        IAddNonSalesEmployeeModel AddNonSalesEmployee(IAddNonSalesEmployeeModel Employee);
        IEmployeeFullNameModel DeleteNonSalesEmployee(IEmployeeFullNameModel Employee);
        List<DepartmentIDModel> GetDepartmentID();
        List<EmployeeFullNameModel> GetNonSalesEmployeeFullName();
        List<NonSalesEmployeeInformationModel> GetNonSalesEmployeeInformation();
        List<StateProvinceIDModel> GetStateProvinceID();
        List<UpdateNonSalesEmployeeModel> GetUpdatedEmployeeInformation(string personName);
        ILoginModel Login(ILoginModel Login);
        IUpdateNonSalesEmployeeModel UpdateNonSalesEmployee(IUpdateNonSalesEmployeeModel Employee);
    }
}