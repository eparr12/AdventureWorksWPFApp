﻿using AdventureWorksWPFClassLibrary.Models;
using AdventureWorksWPFClassLibrary.Models.DropDowns;
using AdventureWorksWPFClassLibrary.SqlDataAccess;
using AdventureWorksWPFClassLibrary.Validators;
using AdventureWorksWPFUI.Models.DropdownListsModels;
using Caliburn.Micro;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace AdventureWorksWPFUI.ViewModels
{
    public class AddNonSalesEmployeeViewModel : Conductor<Screen>.Collection.OneActive, IAddNonSalesEmployeeViewModel
    {
        private StateProvinceIDModel _selectedStateProvinceID;
        private DepartmentIDModel _selectedDepartmentID;
        private List<string> _titles = new();
        private string _selectedTitle;
        private List<string> _suffixs = new();
        private string _selectedSuffix;
        private List<string> _phoneNumberTypes = new();
        private string _selectedPhoneNumberType;
        private List<string> _addressTypeIDs = new();
        private string _selectedAddressTypeID;
        private List<string> _maritals = new();
        private string _selectedMarital;
        private List<string> _genders = new();
        private string _selectedGender;
        private List<string> _payFrequencys = new();
        private string _selectedPayFrequency;
        private List<string> _userRoles = new();
        private string _selectedUserRole;
        private string _firstName;
        private DateTime _hireDate = DateTime.Now;
        private string _postalCode;
        private string _middleName;
        private int _vacationHours;
        private string _lastName;
        private string _emailAddress;
        private int _sickLeaveHours;
        private string _nationalID;
        private decimal _payRate;
        private string _password;
        private string _verifyPassword;
        private string _loginID;
        private string _verifyLoginID;
        private string _phoneNumber;
        private string _jobTitle;
        private DateTime _birthDate = DateTime.Now;
        private string _address;
        private DateTime _startDate = DateTime.Now;
        private bool _yesSalaried;
        private bool _noSalaried;
        private bool _firstShift;
        private bool _secondShift;
        private bool _thirdShift;

        private IDropdownListsModel _dropdownListModel;
        private IDataAccess _dataAccess;
        private IAddNonSalesEmployeeModel Employee;
        private ValidationResult _validationResult;
        private IValidator<IAddNonSalesEmployeeModel> _validator;
        private BindableCollection<StateProvinceIDModel> _stateProvinceIDs;
        private BindableCollection<DepartmentIDModel> _departmentIDs;

        protected override void OnViewLoaded(object AddNonSalesInfoViewModel)
        {
            base.OnViewLoaded(AddNonSalesInfoViewModel);
            ListData();
        }

        public AddNonSalesEmployeeViewModel(IDropdownListsModel dropdownListsModel, IDataAccess dataAccess, 
               IAddNonSalesEmployeeModel employee, IValidator<IAddNonSalesEmployeeModel> validator, 
               ValidationResult validationResult, BindableCollection<StateProvinceIDModel> stateProvinceIDs,
               BindableCollection<DepartmentIDModel> departmentIDs)
        {
            _dropdownListModel = dropdownListsModel;
            _dataAccess = dataAccess;
            Employee = employee;
            _validator = validator;
            _validationResult = validationResult;
            _stateProvinceIDs = stateProvinceIDs;
            _departmentIDs = departmentIDs;
        }

        public BindableCollection<StateProvinceIDModel> StateProvinceIDs
        {
            get
            {
                return _stateProvinceIDs;
            }
            set
            {
                _stateProvinceIDs = value;
                NotifyOfPropertyChange(() => _stateProvinceIDs);
            }
        }

        public StateProvinceIDModel SelectedStateProvinceID
        {
            get
            {
                return _selectedStateProvinceID;
            }
            set
            {
                _selectedStateProvinceID = value;
                NotifyOfPropertyChange(() => SelectedStateProvinceID);
            }
        }

        public BindableCollection<DepartmentIDModel> DepartmentIDs
        {
            get
            {
                return _departmentIDs;
            }
            set
            {
                _departmentIDs = value;
                NotifyOfPropertyChange(() => _departmentIDs);
            }
        }

        public DepartmentIDModel SelectedDepartmentID
        {
            get
            {
                return _selectedDepartmentID;
            }
            set
            {
                _selectedDepartmentID = value;
                NotifyOfPropertyChange(() => SelectedDepartmentID);
            }
        }

        public List<string> Titles
        {
            get
            {
                return _titles;
            }
            set
            {
                _titles = value;
                NotifyOfPropertyChange(() => _titles);
            }
        }

        public string SelectedTitle
        {
            get
            {
                return _selectedTitle;
            }
            set
            {
                _selectedTitle = value;
                NotifyOfPropertyChange(() => SelectedTitle);
            }
        }

        public List<string> Suffixs
        {
            get
            {
                return _suffixs;
            }
            set
            {
                _suffixs = value;
                NotifyOfPropertyChange(() => _suffixs);
            }
        }

        public string SelectedSuffix
        {
            get
            {
                return _selectedSuffix;
            }
            set
            {
                _selectedSuffix = value;
                NotifyOfPropertyChange(() => SelectedSuffix);
            }
        }

        public List<string> PhoneNumberTypes
        {
            get
            {
                return _phoneNumberTypes;
            }
            set
            {
                _phoneNumberTypes = value;
                NotifyOfPropertyChange(() => _phoneNumberTypes);
            }
        }

        public string SelectedPhoneNumberType
        {
            get
            {
                return _selectedPhoneNumberType;
            }
            set
            {
                _selectedPhoneNumberType = value;
                NotifyOfPropertyChange(() => SelectedPhoneNumberType);
            }
        }

        public List<string> AddressTypeIDs
        {
            get
            {
                return _addressTypeIDs;
            }
            set
            {
                _addressTypeIDs = value;
                NotifyOfPropertyChange(() => _addressTypeIDs);
            }
        }

        public string SelectedAddressTypeID
        {
            get
            {
                return _selectedAddressTypeID;
            }
            set
            {
                _selectedAddressTypeID = value;
                NotifyOfPropertyChange(() => SelectedAddressTypeID);
            }
        }

        public List<string> Maritals
        {
            get
            {
                return _maritals;
            }
            set
            {
                _maritals = value;
                NotifyOfPropertyChange(() => _maritals);
            }
        }

        public string SelectedMarital
        {
            get
            {
                return _selectedMarital;
            }
            set
            {
                _selectedMarital = value;
                NotifyOfPropertyChange(() => SelectedMarital);
            }
        }

        public List<string> Genders
        {
            get
            {
                return _genders;
            }
            set
            {
                _genders = value;
                NotifyOfPropertyChange(() => _genders);
            }
        }

        public string SelectedGender
        {
            get
            {
                return _selectedGender;
            }
            set
            {
                _selectedGender = value;
                NotifyOfPropertyChange(() => SelectedGender);
            }
        }

        public List<string> PayFrequencys
        {
            get
            {
                return _payFrequencys;
            }
            set
            {
                _payFrequencys = value;
                NotifyOfPropertyChange(() => _payFrequencys);
            }
        }

        public string SelectedPayFrequency
        {
            get
            {
                return _selectedPayFrequency;
            }
            set
            {
                _selectedPayFrequency = value;
                NotifyOfPropertyChange(() => SelectedPayFrequency);
            }
        }

        public List<string> UserRoles
        {
            get
            {
                return _userRoles;
            }
            set
            {
                _userRoles = value;
                NotifyOfPropertyChange(() => _userRoles);
            }
        }

        public string SelectedUserRole
        {
            get
            {
                return _selectedUserRole;
            }
            set
            {
                _selectedUserRole = value;
                NotifyOfPropertyChange(() => SelectedUserRole);
            }
        }

        public string FirstName
        {
            get
            {
                return
                    _firstName;
            }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }

        public DateTime HireDate
        {
            get
            {
                return
                    _hireDate;
            }
            set
            {
                _hireDate = value;
                NotifyOfPropertyChange(() => HireDate);
            }
        }

        public string PostalCode
        {
            get
            {
                return _postalCode;
            }
            set
            {
                _postalCode = value;
                NotifyOfPropertyChange(() => PostalCode);
            }
        }

        public string MiddleName
        {
            get
            {
                return _middleName;
            }
            set
            {
                _middleName = value;
                NotifyOfPropertyChange(() => MiddleName);
            }
        }

        public int VacationHours
        {
            get
            {
                return _vacationHours;
            }
            set
            {
                _vacationHours = value;
                NotifyOfPropertyChange(() => VacationHours);
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
            }
        }

        public string EmailAddress
        {
            get
            {
                return _emailAddress;
            }
            set
            {
                _emailAddress = value;
                NotifyOfPropertyChange(() => EmailAddress);
            }
        }

        public int SickLeaveHours
        {
            get
            {
                return _sickLeaveHours;
            }
            set
            {
                _sickLeaveHours = value;
                NotifyOfPropertyChange(() => SickLeaveHours);
            }
        }

        public string NationalID
        {
            get
            {
                return _nationalID;
            }
            set
            {
                _nationalID = value;
                NotifyOfPropertyChange(() => NationalID);
            }
        }

        public decimal PayRate
        {
            get
            {
                return _payRate;
            }
            set
            {
                _payRate = value;
                NotifyOfPropertyChange(() => PayRate);
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        public string VerifyPassword
        {
            get
            {
                return _verifyPassword;
            }
            set
            {
                _verifyPassword = value;
                NotifyOfPropertyChange(() => VerifyPassword);
            }
        }

        public string LoginID
        {
            get
            {
                return _loginID;
            }
            set
            {
                _loginID = value;
                NotifyOfPropertyChange(() => LoginID);
            }
        }

        public string VerifyLoginID
        {
            get
            {
                return _verifyLoginID;
            }
            set
            {
                _verifyLoginID = value;
                NotifyOfPropertyChange(() => VerifyLoginID);
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
                NotifyOfPropertyChange(() => PhoneNumber);
            }
        }

        public string JobTitle
        {
            get
            {
                return _jobTitle;
            }
            set
            {
                _jobTitle = value;
                NotifyOfPropertyChange(() => JobTitle);
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                _birthDate = value;
                NotifyOfPropertyChange(() => BirthDate);
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                NotifyOfPropertyChange(() => Address);
            }
        }

        public DateTime StartDate
        {

            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                NotifyOfPropertyChange(() => StartDate);
            }
        }

        private string _city;

        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                NotifyOfPropertyChange(() => City);
            }
        }

        public bool YesSalaried
        {
            get
            {
                return _yesSalaried;
            }
            set
            {
                if (value.Equals(_yesSalaried)) return;
                _yesSalaried = value;
                NotifyOfPropertyChange(() => YesSalaried);
            }
        }

        public bool NoSalaried
        {
            get
            {
                return _noSalaried;
            }
            set
            {
                if (value.Equals(_noSalaried)) return;
                _noSalaried = value;
                NotifyOfPropertyChange(() => NoSalaried);
            }
        }

        public bool FirstShift
        {
            get
            {
                return _firstShift;
            }
            set
            {
                if (value.Equals(_firstShift)) return;
                _firstShift = value;
                NotifyOfPropertyChange(() => FirstShift);
            }
        }

        public bool SecondShift
        {
            get
            {
                return _secondShift;
            }
            set
            {
                if (value.Equals(_secondShift)) return;
                _secondShift = value;
                NotifyOfPropertyChange(() => SecondShift);
            }
        }

        public bool ThirdShift
        {
            get
            {
                return _thirdShift;
            }
            set
            {
                if (value.Equals(_thirdShift)) return;
                _thirdShift = value;
                NotifyOfPropertyChange(() => ThirdShift);
            }
        }

        internal void ListData()
        {
            try
            {
                _dropdownListModel.TitleList(Titles);
                _dropdownListModel.SuffixList(Suffixs);
                _dropdownListModel.PhoneNumberTypeList(PhoneNumberTypes);
                _dropdownListModel.AddressTypeIDList(AddressTypeIDs);
                _dropdownListModel.MaritalStatusList(Maritals);
                _dropdownListModel.GenderList(Genders);
                _dropdownListModel.PayFrequencyList(PayFrequencys);
                _dropdownListModel.UserRoleList(UserRoles);
                _dropdownListModel.StateProvinceIDList(StateProvinceIDs);
                _dropdownListModel.DepartmentIDList(DepartmentIDs);
            }
            catch (SqlException)
            {
                MessageBox.Show("There was an error when performing this operation.\nPlease verify that all entered information is correct.\nCheck the database table DB_Errors for more information.");
            }
        }

        public void Submit()
        {
            var result = MessageBox.Show("Are You Sure You Want To Add This Person??", "Confirm Add!!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (SelectedDepartmentID == null)
                    {
                        MessageBox.Show("Please Select A Value For Department.");
                        return;
                    }

                    if (SelectedStateProvinceID == null)
                    {
                        MessageBox.Show("Please Select A Value For State/Province.");
                        return;
                    }

                    bool salariedFlag = false;
                    if (YesSalaried)
                    {
                        salariedFlag = true;
                    }

                    else if (NoSalaried)
                    {
                        salariedFlag = false;
                    }
                    else
                    {
                        MessageBox.Show("Please Select A Value For Salaried Field.");
                        return;
                    }

                    int shiftId = 1;
                    if (FirstShift)
                    {
                        shiftId = 1;
                    }

                    else if (SecondShift)
                    {
                        shiftId = 2;
                    }

                    else if (ThirdShift)
                    {
                        shiftId = 3;
                    }
                    else
                    {
                        MessageBox.Show("Please Select A Value For Shift.");
                        return;
                    }

                    {
                        Employee.Title = SelectedTitle;
                        Employee.FirstName = FirstName;
                        Employee.MiddleName = MiddleName;
                        Employee.LastName = LastName;
                        Employee.Suffix = SelectedSuffix;
                        Employee.Password = Password;
                        Employee.PhoneNumber = PhoneNumber;
                        Employee.PhoneNumberTypeID = SelectedPhoneNumberType;
                        Employee.AddressLine1 = Address;
                        Employee.City = City;
                        Employee.StateProvinceID = SelectedStateProvinceID.Name;
                        Employee.PostalCode = PostalCode;
                        Employee.AddressTypeID = SelectedAddressTypeID;
                        Employee.EmailAddress = EmailAddress;
                        Employee.NationalIDNumber = NationalID;
                        Employee.LoginID = LoginID;
                        Employee.JobTitle = JobTitle;
                        Employee.BirthDate = BirthDate;
                        Employee.MaritalStatus = SelectedMarital;
                        Employee.Gender = SelectedGender;
                        Employee.HireDate = HireDate;
                        Employee.SalariedFlag = salariedFlag;
                        Employee.VacationHours = VacationHours;
                        Employee.SickLeaveHours = SickLeaveHours;
                        Employee.Rate = PayRate;
                        Employee.PayFrequency = SelectedPayFrequency;
                        Employee.DepartmentID = SelectedDepartmentID.Name;
                        Employee.ShiftID = shiftId;
                        Employee.StartDate = StartDate;
                        Employee.Role = SelectedUserRole;

                        if (Password != VerifyPassword)
                        {
                            MessageBox.Show("Password and Verify Password Do Not Match.");
                            return;
                        }

                        if (LoginID != VerifyLoginID)
                        {
                            MessageBox.Show("LoginID and Verify LoginID Do Not Match.");
                            return;
                        }

                        else
                        {

                            _validationResult = _validator.Validate(Employee);

                            if (_validationResult.IsValid == false)
                            {
                                foreach (ValidationFailure failure in _validationResult.Errors)
                                {
                                    MessageBox.Show(failure.ErrorMessage);
                                    return;
                                }
                            }

                            _dataAccess.AddNonSalesEmployee(Employee);

                            SelectedTitle = "";
                            SelectedSuffix = "";
                            SelectedPhoneNumberType = "";
                            SelectedAddressTypeID = "";
                            SelectedMarital = "";
                            SelectedGender = "";
                            SelectedPayFrequency = "";
                            SelectedUserRole = "";
                            SelectedStateProvinceID.Name = "Ain";
                            SelectedDepartmentID.Name = "Document Control";
                            PostalCode = "";
                            FirstName = "";
                            City = "";
                            LoginID = "";
                            MiddleName = "";
                            VacationHours = 0;
                            LastName = "";
                            EmailAddress = "";
                            SickLeaveHours = 0;
                            NationalID = "";
                            PayRate = 0;
                            Password = "";
                            PhoneNumber = "";
                            JobTitle = "";
                            BirthDate = DateTime.Now;
                            Address = "";
                            HireDate = DateTime.Now;
                            StartDate = DateTime.Now;
                            YesSalaried = false;
                            NoSalaried = false;
                            FirstShift = false;
                            SecondShift = false;
                            ThirdShift = false;

                            MessageBox.Show("Success!");
                        }
                    }
                }

                catch (SqlException)
                {
                    MessageBox.Show("There was an error when performing this operation.\nPlease verify that all entered information is correct.\nCheck the database table DB_Errors for more information.");
                }
            }
        }
    }
}
