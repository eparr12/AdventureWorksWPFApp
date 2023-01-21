using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Data;
using System.Windows;
using AdventureWorksWPFUI.Models.DropdownListsModels;
using FluentValidation.Results;
using AdventureWorksWPFClassLibrary.Models.DropDowns;
using AdventureWorksWPFClassLibrary.SqlDataAccess;
using AdventureWorksWPFClassLibrary.Models;
using AdventureWorksWPFClassLibrary.Validators;
using FluentValidation;

///TODO Remove Unnecessary usings at the end of project

///TODO Remove unnecessary Interfaces

namespace AdventureWorksWPFUI.ViewModels
{
    public class UpdateNonSalesEmployeeViewModel : Conductor<Screen>.Collection.OneActive, IUpdateNonSalesEmployeeViewModel
    {
        private EmployeeFullNameModel _selectedEmployeeFullName;
        private StateProvinceIDModel _selectedStateProvinceID;
        private DepartmentIDModel _selectedDepartmentID;
        private List<string> _titles = new List<string>();
        private string _selectedTitle;
        private List<string> _suffixs = new List<string>();
        private string _selectedSuffix;
        private List<string> _phoneNumberTypes = new List<string>();
        private string _selectedPhoneNumberType;
        private List<string> _addressTypeIDs = new List<string>();
        private string _selectedAddressTypeID;
        private List<string> _maritals = new List<string>();
        private string _selectedMarital;
        private List<string> _genders = new List<string>();
        private string _selectedGender;
        private List<string> _payFrequencys = new List<string>();
        private string _selectedPayFrequency;
        private List<string> _personTypes = new List<string>();
        private string _selectedPersonType;
        private string _firstName;
        private DateTime _hireDate = DateTime.Now;
        private string _loginID;
        private string _verifyLoginID;
        private string _postalCode;
        private string _middleName;
        private int _vacationHours;
        private string _lastName;
        private string _emailAddress;
        private int _sickLeaveHours;
        private string _nationalID;
        private decimal _payRate;
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
        private bool _yesCurrent;
        private bool _noCurrent;

        private IDropdownListsModel _dropdownListModel;
        private IDataAccess _dataAccess;
        private ValidationResult _validationResult;
        private IValidator<IUpdateNonSalesEmployeeModel> _validator;
        private IUpdateNonSalesEmployeeModel Employee;
        private List<UpdateNonSalesEmployeeModel> EmployeeSelection;
        private List<EmployeeFullNameModel> Employees;
        private BindableCollection<EmployeeFullNameModel> _employeeFullNames;
        private BindableCollection<StateProvinceIDModel> _stateProvinceIDs;
        private BindableCollection<DepartmentIDModel> _departmentIDs;

        protected override void OnViewLoaded(object UpdateNonSalesInfoViewModel)
        {
            base.OnViewLoaded(UpdateNonSalesInfoViewModel);
            ListData();
        }

        public UpdateNonSalesEmployeeViewModel(IDropdownListsModel dropdownListModel, IDataAccess dataAccess,
                                               IValidator<IUpdateNonSalesEmployeeModel> validator, ValidationResult validationResult,
                                               IUpdateNonSalesEmployeeModel employee, List<UpdateNonSalesEmployeeModel> employeeSelection
,                                              BindableCollection<EmployeeFullNameModel> employeeFullNames,
                                               BindableCollection<StateProvinceIDModel> stateProvinceIDs, List<EmployeeFullNameModel> employees
,                                              BindableCollection<DepartmentIDModel> departmentIDs)
        {
            _dropdownListModel = dropdownListModel;
            _dataAccess = dataAccess;
            _validationResult = validationResult;
            _validator = validator;
            Employee = employee;
            EmployeeSelection = employeeSelection;
            _employeeFullNames = employeeFullNames;
            _stateProvinceIDs = stateProvinceIDs;
            Employees = employees;
            _departmentIDs = departmentIDs;
        }

        public ICollectionView Collection
        {
            get;

            set;
        }

        public BindableCollection<EmployeeFullNameModel> EmployeeFullNames
        {
            get
            {
                return _employeeFullNames;
            }
            set
            {
                _employeeFullNames = value;
                NotifyOfPropertyChange(() => EmployeeFullNames);
                Collection.Refresh();
            }
        }

        public EmployeeFullNameModel SelectedEmployeeFullName
        {
            get
            {
                return _selectedEmployeeFullName;
            }
            set
            {
                _selectedEmployeeFullName = value;

                NotifyOfPropertyChange(() => SelectedEmployeeFullName);

                if (SelectedEmployeeFullName != null)
                {
                    EmployeeSelection = _dataAccess.GetUpdatedEmployeeInformation(SelectedEmployeeFullName.FullName);

                    foreach (UpdateNonSalesEmployeeModel Employee in EmployeeSelection)
                    {
                        SelectedPersonType = Employee.PersonType2;
                        SelectedTitle = Employee.Title;
                        FirstName = Employee.FirstName;
                        MiddleName = Employee.MiddleName;
                        LastName = Employee.LastName;
                        SelectedSuffix = Employee.Suffix;
                        PhoneNumber = Employee.PhoneNumber;
                        SelectedPhoneNumberType = Employee.PhoneNumberType;
                        Address = Employee.AddressLine1;
                        City = Employee.City;
                        PostalCode = Employee.PostalCode;
                        SelectedAddressTypeID = Employee.AddressTypeID;
                        EmailAddress = Employee.EmailAddress;
                        NationalID = Employee.SocialSecurityNumber;
                        LoginID = Employee.LoginID;
                        JobTitle = Employee.JobTitle;
                        BirthDate = Employee.BirthDate;
                        SelectedMarital = Employee.MaritalStatus;
                        SelectedGender = Employee.Gender;
                        HireDate = Employee.HireDate;
                        VacationHours = Employee.VacationHours;
                        SickLeaveHours = Employee.SickLeaveHours;
                        PayRate = decimal.Parse(Employee.HourlyPayRate);
                        SelectedPayFrequency = Employee.PayFrequency;
                        StartDate = Employee.StartDate;
                        bool? salaried = Employee.SalariedFlag;
                        bool? current = Employee.CurrentEmployee;
                        int shift = Employee.ShiftID;

                        if (salaried == true)
                        {
                            YesSalaried = true;
                            salaried = null;
                        }
                        else if (salaried == false)
                        {
                            NoSalaried = true;
                            salaried = null;
                        }

                        if (current == true)
                        {
                            YesCurrent = true;
                            current = null;
                        }
                        else if (current == false)
                        {
                            NoCurrent = true;
                            current = null;
                        }

                        if (shift == 1)
                        {
                            FirstShift = true;
                            shift = 0;
                        }
                        else if (shift == 2)
                        {
                            SecondShift = true;
                            shift = 0;
                        }
                        else if (shift == 3)
                        {
                            ThirdShift = true;
                            shift = 0;
                        }
                    }
                }
            }
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

        public List<string> PersonTypes
        {
            get
            {
                return _personTypes;
            }
            set
            {
                _personTypes = value;
                NotifyOfPropertyChange(() => PersonTypes);
            }
        }

        public string SelectedPersonType
        {
            get
            {
                return _selectedPersonType;
            }
            set
            {
                _selectedPersonType = value;
                NotifyOfPropertyChange(() => SelectedPersonType);
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

        public bool YesCurrent
        {
            get
            {
                return _yesCurrent;
            }
            set
            {
                if (value.Equals(_yesCurrent)) return;
                _yesCurrent = value;
                NotifyOfPropertyChange(() => YesCurrent);
            }
        }

        public bool NoCurrent
        {
            get
            {
                return _noCurrent;
            }
            set
            {
                if (value.Equals(_noCurrent)) return;
                _noCurrent = value;
                NotifyOfPropertyChange(() => NoCurrent);
            }
        }

        internal void ListData()
        {
            try
            {
                Employees = _dataAccess.GetNonSalesEmployeeFullName();

                foreach (EmployeeFullNameModel e in Employees)
                {
                    EmployeeFullNames.Add(e);
                }

                Collection = CollectionViewSource.GetDefaultView(_employeeFullNames);

                Collection.SortDescriptions.Add(new SortDescription(nameof(EmployeeFullNameModel.FullName), ListSortDirection.Ascending));

                _dropdownListModel.TitleList(Titles);
                _dropdownListModel.SuffixList(Suffixs);
                _dropdownListModel.PhoneNumberTypeList(PhoneNumberTypes);
                _dropdownListModel.AddressTypeIDList(AddressTypeIDs);
                _dropdownListModel.MaritalStatusList(Maritals);
                _dropdownListModel.GenderList(Genders);
                _dropdownListModel.PayFrequencyList(PayFrequencys);
                _dropdownListModel.StateProvinceIDList(StateProvinceIDs);
                _dropdownListModel.DepartmentIDList(DepartmentIDs);
                _dropdownListModel.PersonTypeList(PersonTypes);
            }
            catch (SqlException)
            {
                MessageBox.Show("There was an error when performing this operation.\nPlease verify that all entered information is correct.\nCheck the database table DB_Errors for more information.");
            }
        }

        public void Submit()
        {
            var result = MessageBox.Show("Are You Sure You Want To Update??", "Confirm Update!!", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (SelectedEmployeeFullName == null)
                    {
                        MessageBox.Show("Please Selecte A Value For Employee.");
                        return;
                    }

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

                    bool CurrentEmployee = true;
                    if (YesCurrent)
                    {
                        CurrentEmployee = true;
                    }

                    else if (NoCurrent)
                    {
                        CurrentEmployee = false;
                    }
                    else
                    {
                        MessageBox.Show("Please Selecte A Value For Active.");
                        return;
                    }

                    {
                        Employee.FullName = SelectedEmployeeFullName.FullName;
                        Employee.Title = SelectedTitle;
                        Employee.FirstName = FirstName;
                        Employee.MiddleName = MiddleName;
                        Employee.LastName = LastName;
                        Employee.Suffix = SelectedSuffix;
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
                        Employee.PersonType = SelectedPersonType;
                        Employee.DepartmentID = SelectedDepartmentID.Name;
                        Employee.ShiftID = shiftId;
                        Employee.StartDate = StartDate;
                        Employee.CurrentEmployee = CurrentEmployee;

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

                            _dataAccess.UpdateNonSalesEmployee(Employee);

                            SelectedTitle = "";
                            SelectedSuffix = "";
                            SelectedPhoneNumberType = "";
                            SelectedAddressTypeID = "";
                            SelectedMarital = "";
                            SelectedGender = "";
                            SelectedPayFrequency = "";
                            SelectedStateProvinceID.Name = "Ain";
                            SelectedDepartmentID.Name = "Document Control";
                            SelectedPersonType = "";
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
                            YesCurrent = false;
                            NoCurrent = false;

                            EmployeeFullNames.Clear();
                            ListData();

                            MessageBox.Show("Success!");
                        }
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("There was an error when performing this operation.\nPlease verify that all entered information is correct.\nCheck the database table DB_Errors for more information.");
                }
            }
            else
            {
                return;
            }
        }
    }
}
