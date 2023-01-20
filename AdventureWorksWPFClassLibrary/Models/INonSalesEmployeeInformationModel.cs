namespace AdventureWorksWPFClassLibrary.Models
{
    public interface INonSalesEmployeeInformationModel
    {
        string AddressLine1 { get; set; }
        DateTime BirthDate { get; set; }
        string City { get; set; }
        string Country { get; set; }
        string EmailAddress { get; set; }
        string FormatBirthDate { get; }
        string FormatHireDate { get; }
        string FormatHourlyPay { get; }
        string Gender { get; set; }
        DateTime HireDate { get; set; }
        decimal HourlyPayRate { get; set; }
        string JobDepartment { get; set; }
        string JobGroup { get; set; }
        string JobTitle { get; set; }
        string LoginID { get; set; }
        string MaritalStatus { get; set; }
        string PayFrequency { get; set; }
        int PersonID { get; set; }
        string PersonName { get; set; }
        string PersonType { get; set; }
        string PhoneNumber { get; set; }
        string PhoneNumberType { get; set; }
        string PostalCode { get; set; }
        string ShiftName { get; set; }
        string ShiftNumber { get; set; }
        int SickLeaveHours { get; set; }
        string SocialSecurityNumber { get; set; }
        string StateOrProvince { get; set; }
        int VacationHours { get; set; }
    }
}