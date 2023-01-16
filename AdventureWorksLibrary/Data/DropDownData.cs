using AdventureWorksLibrary.DataAccess;
using AdventureWorksLibrary.Models.DropDowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksLibrary.Data
{
    public class DropDownData : IDropDownData
    {
        private readonly ISqlDataAccess _db;
        public DropDownData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<EmployeeFullNameModel>> GetNonSalesEmployeeFullNames() =>
_db.LoadData<EmployeeFullNameModel, dynamic>("SP_DropdownNonSalesemployeeFullName", new { });

        public Task<IEnumerable<StateProvinceIDModel>> GetStateProvinceIDs() =>
   _db.LoadData<StateProvinceIDModel, dynamic>("SP_DropdownStateProvinceIDs", new { });

        public Task<IEnumerable<DepartmentIDModel>> GetDepartmentIDs() =>
   _db.LoadData<DepartmentIDModel, dynamic>("SP_DropdownDepartmentIDs", new { });

    }
}
