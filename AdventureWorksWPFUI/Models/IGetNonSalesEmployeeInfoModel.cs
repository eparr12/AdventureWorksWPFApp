namespace AdventureWorksWPFUI.Models
{
    public interface IGetNonSalesEmployeeInfoModel
    {
        string AddressLine1 { get; set; }
        string City { get; set; }
        string Country { get; set; }
        string EmailAddress { get; set; }
        string FormatBirthDate { get; set; }
        string FormatHireDate { get; set; }
        string FormatHourlyPay { get; set; }
        string Gender { get; set; }
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
        int SickLeaveHours { get; set; }
        string SocialSecurityNumber { get; set; }
        string StateOrProvince { get; set; }
        int VacationHours { get; set; }
    }
}