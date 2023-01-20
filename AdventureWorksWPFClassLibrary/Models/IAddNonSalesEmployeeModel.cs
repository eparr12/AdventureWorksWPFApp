namespace AdventureWorksWPFClassLibrary.Models
{
    public interface IAddNonSalesEmployeeModel
    {
        string AddressLine1 { get; set; }
        string AddressTypeID { get; set; }
        DateTime BirthDate { get; set; }
        string City { get; set; }
        string DepartmentID { get; set; }
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string Gender { get; set; }
        DateTime HireDate { get; set; }
        string JobTitle { get; set; }
        string LastName { get; set; }
        string LoginID { get; set; }
        string MaritalStatus { get; set; }
        string MiddleName { get; set; }
        string NationalIDNumber { get; set; }
        string Password { get; set; }
        string PayFrequency { get; set; }
        string PhoneNumber { get; set; }
        string PhoneNumberTypeID { get; set; }
        string PostalCode { get; set; }
        decimal Rate { get; set; }
        string Role { get; set; }
        bool SalariedFlag { get; set; }
        int ShiftID { get; set; }
        int SickLeaveHours { get; set; }
        DateTime StartDate { get; set; }
        string StateProvinceID { get; set; }
        string Suffix { get; set; }
        string Title { get; set; }
        int VacationHours { get; set; }
    }
}