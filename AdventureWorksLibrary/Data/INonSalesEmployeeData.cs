using AdventureWorksLibrary.Models;

namespace AdventureWorksLibrary.Data
{
    public interface INonSalesEmployeeData
    {
        Task AddNonSalesEmployee(AddNonSalesEmployeeModel employee);
        Task DeleteNonSalesEmployee(string fullName);
        Task<NonSalesEmployeeInformationModel?> GetNonSalesEmployee(string employeeFullName);
        Task<IEnumerable<NonSalesEmployeeInformationModel>> GetNonSalesEmployees();
        Task UpdateNonSalesEmployee(UpdateNonSalesEmployeeModel employee);
    }
}