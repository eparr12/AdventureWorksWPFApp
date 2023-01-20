using AdventureWorksWPFClassLibrary.Models.DropDowns;
using Caliburn.Micro;
using System.Collections.Generic;

namespace AdventureWorksWPFUI.Models.DropdownListsModels
{
    public interface IDropdownListsModel
    {
        void AddressTypeIDList(List<string> addressTypeID);
        void DepartmentIDList(BindableCollection<DepartmentIDModel> departmentID);
        void GenderList(List<string> gender);
        void MaritalStatusList(List<string> maritalStatus);
        void PayFrequencyList(List<string> payFrequency);
        void PersonTypeList(List<string> personType);
        void PhoneNumberTypeList(List<string> phoneNumberType);
        void StateProvinceIDList(BindableCollection<StateProvinceIDModel> stateProvinceID);
        void SuffixList(List<string> suffix);
        void TitleList(List<string> title);
        void UserRoleList(List<string> userRole);
    }
}