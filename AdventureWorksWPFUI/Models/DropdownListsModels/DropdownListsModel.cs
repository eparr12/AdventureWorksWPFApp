using AdventureWorksWPFClassLibrary.Models.DropDowns;
using AdventureWorksWPFClassLibrary.SqlDataAccess;
using Caliburn.Micro;
using System.Collections.Generic;

namespace AdventureWorksWPFUI.Models.DropdownListsModels
{
    public class DropdownListsModel : IDropdownListsModel
    {
        IDataAccess _dataAccess;
        List<StateProvinceIDModel> _stateProvinceID;
        List<DepartmentIDModel> _departmentID;

        public DropdownListsModel(List<StateProvinceIDModel> stateProvinceID,
                                  List<DepartmentIDModel> departmentID, IDataAccess dataAccess) 
        {
            _stateProvinceID = stateProvinceID;
            _departmentID = departmentID;
            _dataAccess = dataAccess;
        }

        public void StateProvinceIDList(BindableCollection<StateProvinceIDModel> stateProvinceID)
        {
            _stateProvinceID = _dataAccess.GetStateProvinceID();

            foreach (StateProvinceIDModel e in _stateProvinceID)
            {
                stateProvinceID.Add(e);
            }
        }

        public void DepartmentIDList(BindableCollection<DepartmentIDModel> departmentID)
        {
            _departmentID = _dataAccess.GetDepartmentID();

            foreach (DepartmentIDModel e in _departmentID)
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
            addressTypeID.Add("Archive");
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
            gender.Add("Female");
            gender.Add("Male");
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

        public void PersonTypeList(List<string> personType)
        {
            personType.Add("");
            personType.Add("SC");
            personType.Add("IN");
            personType.Add("SP");
            personType.Add("EM");
            personType.Add("VC");
            personType.Add("GC");
        }
    }
}
