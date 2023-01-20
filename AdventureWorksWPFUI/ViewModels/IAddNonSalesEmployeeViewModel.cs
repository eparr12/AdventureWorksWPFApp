using AdventureWorksWPFClassLibrary.Models.DropDowns;
using Caliburn.Micro;
using System;
using System.Collections.Generic;

namespace AdventureWorksWPFUI.ViewModels
{
    public interface IAddNonSalesEmployeeViewModel
    {
        string Address { get; set; }
        List<string> AddressTypeIDs { get; set; }
        DateTime BirthDate { get; set; }
        string City { get; set; }
        BindableCollection<DepartmentIDModel> DepartmentIDs { get; set; }
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        bool FirstShift { get; set; }
        List<string> Genders { get; set; }
        DateTime HireDate { get; set; }
        string JobTitle { get; set; }
        string LastName { get; set; }
        string LoginID { get; set; }
        List<string> Maritals { get; set; }
        string MiddleName { get; set; }
        string NationalID { get; set; }
        bool NoSalaried { get; set; }
        string Password { get; set; }
        List<string> PayFrequencys { get; set; }
        decimal PayRate { get; set; }
        string PhoneNumber { get; set; }
        List<string> PhoneNumberTypes { get; set; }
        string PostalCode { get; set; }
        bool SecondShift { get; set; }
        string SelectedAddressTypeID { get; set; }
        DepartmentIDModel SelectedDepartmentID { get; set; }
        string SelectedGender { get; set; }
        string SelectedMarital { get; set; }
        string SelectedPayFrequency { get; set; }
        string SelectedPhoneNumberType { get; set; }
        StateProvinceIDModel SelectedStateProvinceID { get; set; }
        string SelectedSuffix { get; set; }
        string SelectedTitle { get; set; }
        string SelectedUserRole { get; set; }
        int SickLeaveHours { get; set; }
        DateTime StartDate { get; set; }
        BindableCollection<StateProvinceIDModel> StateProvinceIDs { get; set; }
        List<string> Suffixs { get; set; }
        bool ThirdShift { get; set; }
        List<string> Titles { get; set; }
        List<string> UserRoles { get; set; }
        int VacationHours { get; set; }
        string VerifyLoginID { get; set; }
        string VerifyPassword { get; set; }
        bool YesSalaried { get; set; }

        void Submit();
    }
}