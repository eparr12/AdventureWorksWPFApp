﻿using AdventureWorksWPFClassLibrary.Models;
using AdventureWorksWPFClassLibrary.Models.DropDowns;
using AutoMapper;
using Dapper;
using Microsoft.VisualBasic;
using System.Data;

namespace AdventureWorksWPFClassLibrary.SqlDataAccess
{
    public class DataAccess : IDataAccess
    {
        public ILoginModel Login(ILoginModel Login)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(SqlHelper.CnnVal("AdventureWorks2014")))
            {
                var p = new DynamicParameters();
                p.Add("@LoginID", Login.LoginID);
                p.Add("@Password", Login.Password);
                p.Add("@Role", "", DbType.String, ParameterDirection.Output);

                connection.Execute("SP_UserLogin", p, commandType: CommandType.StoredProcedure);

                Login.Role = p.Get<string>("@Role");

                return Login;
            }

        }

        public IAddNonSalesEmployeeModel AddNonSalesEmployee(IAddNonSalesEmployeeModel Employee)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(SqlHelper.CnnVal("AdventureWorks2014")))
            {
                var p = new DynamicParameters();
                p.Add("@Title", Employee.Title);
                p.Add("@FirstName", Employee.FirstName);
                p.Add("@MiddleName", Employee.MiddleName);
                p.Add("@LastName", Employee.LastName);
                p.Add("@Suffix", Employee.Suffix);
                p.Add("@Password", Employee.Password);
                p.Add("@PhoneNumber", Employee.PhoneNumber);
                p.Add("@PhoneNumberTypeID", Employee.PhoneNumberTypeID);
                p.Add("@AddressLine1", Employee.AddressLine1);
                p.Add("@City", Employee.City);
                p.Add("@StateProvinceID", Employee.StateProvinceID);
                p.Add("@PostalCode", Employee.PostalCode);
                p.Add("@AddressTypeID", Employee.AddressTypeID);
                p.Add("@EmailAddress", Employee.EmailAddress);
                p.Add("@NationalIDNumber", Employee.NationalIDNumber);
                p.Add("@LoginID", Employee.LoginID);
                p.Add("@JobTitle", Employee.JobTitle);
                p.Add("@BirthDate", Employee.BirthDate);
                p.Add("@MaritalStatus", Employee.MaritalStatus);
                p.Add("@Gender", Employee.Gender);
                p.Add("@HireDate", Employee.HireDate);
                p.Add("@SalariedFlag", Employee.SalariedFlag);
                p.Add("@VacationHours", Employee.VacationHours);
                p.Add("@SickLeaveHours", Employee.SickLeaveHours);
                p.Add("@Rate", Employee.Rate);
                p.Add("@PayFrequency", Employee.PayFrequency);
                p.Add("@DepartmentID", Employee.DepartmentID);
                p.Add("@ShiftID", Employee.ShiftID);
                p.Add("@StartDate", Employee.StartDate);
                p.Add("@Role", Employee.Role);

                connection.Execute("SP_AddNonSalesEmployee", p, commandType: CommandType.StoredProcedure);

                return Employee;
            }
        }

        public IEmployeeFullNameModel DeleteNonSalesEmployee(IEmployeeFullNameModel Employee)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(SqlHelper.CnnVal("AdventureWorks2014")))
            {
                var p = new DynamicParameters();
                p.Add("@EmployeeFullName", Employee.FullName);

                connection.Execute("SP_DeleteEmployees", p, commandType: CommandType.StoredProcedure);

                return Employee;
            }
        }

        public List<NonSalesEmployeeInformationModel> GetNonSalesEmployeeInformation()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(SqlHelper.CnnVal("AdventureWorks2014")))
            {

                var output = connection.Query<NonSalesEmployeeInformationModel>($"select * from v_GetNonSalesEmployeeInformation").ToList();

                return output;
            }
        }

        public List<UpdateNonSalesEmployeeModel> GetUpdatedEmployeeInformation(string personName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(SqlHelper.CnnVal("AdventureWorks2014")))
            {

                var output = connection.Query<UpdateNonSalesEmployeeModel>("SP_GetPersonInformation @PersonName", new { PersonName = personName }).ToList();

                return output;

            }
        }

        public IUpdateNonSalesEmployeeModel UpdateNonSalesEmployee(IUpdateNonSalesEmployeeModel Employee)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(SqlHelper.CnnVal("AdventureWorks2014")))
            {
                var p = new DynamicParameters();
                p.Add("@FullName", Employee.FullName);
                p.Add("@PersonType", Employee.PersonType);
                p.Add("@Title", Employee.Title);
                p.Add("@FirstName", Employee.FirstName);
                p.Add("@MiddleName", Employee.MiddleName);
                p.Add("@LastName", Employee.LastName);
                p.Add("@Suffix", Employee.Suffix);
                p.Add("@PhoneNumber", Employee.PhoneNumber);
                p.Add("@PhoneNumberTypeID", Employee.PhoneNumberTypeID);
                p.Add("@AddressLine1", Employee.AddressLine1);
                p.Add("@City", Employee.City);
                p.Add("@StateProvinceID", Employee.StateProvinceID);
                p.Add("@PostalCode", Employee.PostalCode);
                p.Add("@AddressTypeID", Employee.AddressTypeID);
                p.Add("@EmailAddress", Employee.EmailAddress);
                p.Add("@NationalIDNumber", Employee.NationalIDNumber);
                p.Add("@LoginID", Employee.LoginID);
                p.Add("@JobTitle", Employee.JobTitle);
                p.Add("@BirthDate", Employee.BirthDate);
                p.Add("@MaritalStatus", Employee.MaritalStatus);
                p.Add("@Gender", Employee.Gender);
                p.Add("@HireDate", Employee.HireDate);
                p.Add("@SalariedFlag", Employee.SalariedFlag);
                p.Add("@VacationHours", Employee.VacationHours);
                p.Add("@SickLeaveHours", Employee.SickLeaveHours);
                p.Add("@CurrentFlag", Employee.CurrentEmployee);
                p.Add("@Rate", Employee.Rate);
                p.Add("@PayFrequency", Employee.PayFrequency);
                p.Add("@DepartmentID", Employee.DepartmentID);
                p.Add("@ShiftID", Employee.ShiftID);
                p.Add("@StartDate", Employee.StartDate);

                connection.Execute("SP_UpdateNonSalesEmployee", p, commandType: CommandType.StoredProcedure);

                return Employee;
            }
        }

        public List<StateProvinceIDModel> GetStateProvinceID()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(SqlHelper.CnnVal("AdventureWorks2014")))
            {
                var output = connection.Query<StateProvinceIDModel>($"select * from v_DropdownStateProvinceID").ToList();
                return output;
            }
        }

        public List<DepartmentIDModel> GetDepartmentID()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(SqlHelper.CnnVal("AdventureWorks2014")))
            {
                var output = connection.Query<DepartmentIDModel>($"select * from v_DropdownDepartmentID").ToList();
                return output;
            }
        }

        public List<EmployeeFullNameModel> GetNonSalesEmployeeFullName()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(SqlHelper.CnnVal("AdventureWorks2014")))
            {
                var output = connection.Query<EmployeeFullNameModel>($"select * from v_DropdownNonSalesEmployeeFullName").ToList();

                return output;
            }
        }
    }
}
