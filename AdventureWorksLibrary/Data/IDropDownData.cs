using AdventureWorksLibrary.Models.DropDowns;

namespace AdventureWorksLibrary.Data
{
    public interface IDropDownData
    {
        Task<IEnumerable<EmployeeFullNameModel>> GetNonSalesEmployeeFullNames();
        Task<IEnumerable<DepartmentIDModel>> GetDepartmentIDs();
        Task<IEnumerable<StateProvinceIDModel>> GetStateProvinceIDs();
    }
}