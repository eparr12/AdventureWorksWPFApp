using AdventureWorksWPFClassLibrary.Models;
using AdventureWorksWPFClassLibrary.Models.DropDowns;

namespace AdventureWorksWPFClassLibrary.SqlDataAccess
{
    public interface IDataAccess
    {
        AddNonSalesEmployeeModel AddNonSalesEmployee(AddNonSalesEmployeeModel Employee);
        EmployeeFullNameModel DeleteNonSalesEmployee(EmployeeFullNameModel Employee);
        List<DepartmentIDModel> GetDepartmentID();
        List<EmployeeFullNameModel> GetNonSalesEmployeeFullName();
        List<NonSalesEmployeeInformationModel> GetNonSalesEmployeeInformation();
        List<StateProvinceIDModel> GetStateProvinceID();
        List<UpdateNonSalesEmployeeModel> GetUpdatedEmployeeInformation(string personName);
        ILoginModel Login(ILoginModel Login);
        UpdateNonSalesEmployeeModel UpdateNonSalesEmployee(UpdateNonSalesEmployeeModel Employee);
    }
}