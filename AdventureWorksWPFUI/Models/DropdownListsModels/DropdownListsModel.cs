using AdventureWorksLibrary.Models.DropDowns;
using AdventureWorksLibrary.SqlDataAccess;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksWPFUI.Models.DropdownListsModels
{
    public class DropdownListsModel
    {
        List <StateProvinceIDModel> StateProvinceID = new List<StateProvinceIDModel>();
        List<DepartmentIDModel> DepartmentID = new List<DepartmentIDModel>();

        public void StateProvinceIDList(BindableCollection<StateProvinceIDModel> stateProvinceID)
        {
            DataAccess db = new DataAccess();

            StateProvinceID = db.GetStateProvinceID();

            foreach (StateProvinceIDModel e in StateProvinceID)
            {
                stateProvinceID.Add(e);
            }
        }

        public void DepartmentIDList(BindableCollection<DepartmentIDModel> departmentID)
        {
            DataAccess db = new DataAccess();

            DepartmentID = db.GetDepartmentID();

            foreach (DepartmentIDModel e in DepartmentID)
            {
                departmentID.Add(e);
            }
        }
        public void TitleList(List<string> title)
        {
            title.Add("");
            title.Add("Mr.");
            title.Add("Mrs.");
            title.Add("Ms.");
        }

        public void SuffixList(List<string> suffix)
        {
            suffix.Add("");
            suffix.Add("I");
            suffix.Add("II");
            suffix.Add("III");
            suffix.Add("IV");
            suffix.Add("Jr.");
            suffix.Add("PhD");
            suffix.Add("Sr.");
        }

        public void PhoneNumberTypeList(List<string> phoneNumberType)
        {
            phoneNumberType.Add("");
            phoneNumberType.Add("Cell");
            phoneNumberType.Add("Home");
            phoneNumberType.Add("Work");
        }

        public void AddressTypeIDList(List<string> addressTypeID) 
        {
            addressTypeID.Add("");
            addressTypeID .Add("Archive");
            addressTypeID.Add("Billing");
            addressTypeID.Add("Home");
            addressTypeID.Add("Main Office");
            addressTypeID.Add("Primary");
            addressTypeID.Add("Shipping");
        }

        public void MaritalStatusList(List<string> maritalStatus)
        {
            maritalStatus.Add("");
            maritalStatus.Add("Married");
            maritalStatus.Add("Single");
        }

        public void GenderList(List<string> gender) 
        {
            gender.Add("");
            gender.Add("Male");
            gender.Add("Female");
        }

        public void PayFrequencyList(List<string> payFrequency) 
        {
            payFrequency.Add("");
            payFrequency.Add("Bi-Weekly");
            payFrequency.Add("Weekly");
        }

        public void UserRoleList(List<string> userRole)
        {
            userRole.Add("");
            userRole.Add("Administrator");
            userRole.Add("Basic");
        }
    }
}
