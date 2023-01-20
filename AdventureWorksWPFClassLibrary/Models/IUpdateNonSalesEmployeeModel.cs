namespace AdventureWorksWPFClassLibrary.Models
{
    public interface IUpdateNonSalesEmployeeModel
    {
        string AddressLine1 { get; set; }
        string AddressTypeID { get; set; }
        DateTime BirthDate { get; set; }
        string City { get; set; }
        string Country { get; set; }
        string Currency { get; set; }
        bool CurrentEmployee { get; set; }
        string DepartmentID { get; set; }
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string FullName { get; set; }
        string Gender { get; set; }
        DateTime HireDate { get; set; }
        string HourlyPayRate { get; set; }
        string JobDepartment { get; set; }
        string JobGroup { get; set; }
        string JobTitle { get; set; }
        string LastName { get; set; }
        string LengthOfService { get; set; }
        string LoginID { get; set; }
        string MaritalStatus { get; set; }
        string MiddleName { get; set; }
        string NationalIDNumber { get; set; }
        string Password { get; set; }
        string PayFrequency { get; set; }
        int PersonID { get; set; }
        string PersonType { get; set; }
        string PersonType2 { get; set; }
        string PhoneNumber { get; set; }
        string PhoneNumberType { get; set; }
        string PhoneNumberTypeID { get; set; }
        string PostalCode { get; set; }
        decimal Rate { get; set; }
        bool SalariedFlag { get; set; }
        string SalesTerritory { get; set; }
        int ShiftID { get; set; }
        string ShiftName { get; set; }
        string ShiftNumber { get; set; }
        int SickLeaveHours { get; set; }
        string SocialSecurityNumber { get; set; }
        DateTime StartDate { get; set; }
        string StateOrProvince { get; set; }
        string StateProvinceID { get; set; }
        string Suffix { get; set; }
        string Title { get; set; }
        int VacationHours { get; set; }
    }
}