namespace AdventureWorksWPFUI.Models
{
    public class GetNonSalesEmployeeInfoModel
    {
        public string PersonName { get; set; }
        public int PersonID { get; set; }
        public string PersonType { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string LoginID { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberType { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public string JobGroup { get; set; }
        public string JobDepartment { get; set; }
        public string JobTitle { get; set; }
        public string ShiftName { get; set; }
        public string PayFrequency { get; set; }
        public int VacationHours { get; set; }
        public int SickLeaveHours { get; set; }
        public string FormatHourlyPay { get; set; }
        public string FormatBirthDate { get; set; }
        public string FormatHireDate { get; set; }
    }
}
