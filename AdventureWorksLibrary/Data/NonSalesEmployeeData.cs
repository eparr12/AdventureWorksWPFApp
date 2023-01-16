using AdventureWorksLibrary.DataAccess;
using AdventureWorksLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksLibrary.Data
{
    public class NonSalesEmployeeData : INonSalesEmployeeData
    {
        private readonly ISqlDataAccess _db;

        public NonSalesEmployeeData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<NonSalesEmployeeInformationModel>> GetNonSalesEmployees() =>
            _db.LoadData<NonSalesEmployeeInformationModel, dynamic>("SP_GetNonSalesEmployeeInformation", new { });

        public async Task<NonSalesEmployeeInformationModel?> GetNonSalesEmployee(string employeeFullName)
        {
            var results = await _db.LoadData<NonSalesEmployeeInformationModel, dynamic>(
                "SP_GetPersonInformation", new { PersonName = employeeFullName });
            return results.FirstOrDefault();
        }

        public Task AddNonSalesEmployee(AddNonSalesEmployeeModel employee) =>
            _db.SaveData("SP_AddNonSalesEmployee",
                new
                {
                    employee.Title,
                    employee.FirstName,
                    employee.MiddleName,
                    employee.LastName,
                    employee.Suffix,
                    employee.Password,
                    employee.PhoneNumber,
                    employee.PhoneNumberTypeID,
                    employee.AddressLine1,
                    employee.City,
                    employee.StateProvinceID,
                    employee.PostalCode,
                    employee.AddressTypeID,
                    employee.EmailAddress,
                    employee.NationalIDNumber,
                    employee.LoginID,
                    employee.JobTitle,
                    employee.BirthDate,
                    employee.MaritalStatus,
                    employee.Gender,
                    employee.HireDate,
                    employee.SalariedFlag,
                    employee.VacationHours,
                    employee.SickLeaveHours,
                    employee.Rate,
                    employee.PayFrequency,
                    employee.DepartmentID,
                    employee.ShiftID,
                    employee.StartDate,
                    employee.Role
                });

        public Task UpdateNonSalesEmployee(UpdateNonSalesEmployeeModel employee) =>
            _db.SaveData("SP_UpdateNonSalesEmployee", employee);

        public Task DeleteNonSalesEmployee(string fullName) =>
            _db.SaveData("SP_DeleteEmployees", new { EmployeeFullName = fullName });
    }
}
