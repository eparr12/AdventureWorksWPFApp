﻿using AdventureWorksWPFClassLibrary.Models;
using AdventureWorksWPFClassLibrary.Models.DropDowns;
using AdventureWorksWPFClassLibrary.SqlDataAccess;
using AdventureWorksWPFClassLibrary.Validators;
using Caliburn.Micro;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Data;

/// TODO figure out how to get dapper to work with IEmployeeFullNameModel to populate list

namespace AdventureWorksWPFUI.ViewModels
{
    public class DeleteNonSalesEmployeeViewModel : Conductor<Screen>.Collection.OneActive, IDeleteNonSalesEmployeeViewModel
    {
        private string _searchFilter = string.Empty;
        private BindableCollection<EmployeeFullNameModel> _employeeFullNames = new BindableCollection<EmployeeFullNameModel>();
        private EmployeeFullNameModel _selectedEmployeeFullName;

        List<EmployeeFullNameModel> Employees = new List<EmployeeFullNameModel>();
        private ValidationResult _validationResult;
        private IValidator<IEmployeeFullNameModel> _validator;
        private IDataAccess _dataAccess;
        //private IEmployeeFullNameModel Employee;
        EmployeeFullNameModel Employee = new();

        protected override void OnViewLoaded(object DeleteNonSalesInfoViewModel)
        {
            base.OnViewLoaded(DeleteNonSalesInfoViewModel);
            ListData();

        }

        public DeleteNonSalesEmployeeViewModel(IDataAccess dataAccess, //IEmployeeFullNameModel employee,
               ValidationResult validationResult, IValidator<IEmployeeFullNameModel> validator)
        {
            _dataAccess = dataAccess;
           // Employee = employee;
            _validator = validator;
            _validationResult = validationResult;
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
            }
        }

        public string SearchFilter
        {
            get
            {
                return _searchFilter;
            }
            set
            {
                _searchFilter = value;
                NotifyOfPropertyChange(() => SearchFilter);
                Collection.Refresh();
            }
        }

        private bool FilterEmployees(object obj)
        {
            if (obj is EmployeeFullNameModel filter)
            {
                return filter.FullName.Contains(SearchFilter, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
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

                Collection.Filter = FilterEmployees;
                Collection.SortDescriptions.Add(new SortDescription(nameof(EmployeeFullNameModel.FullName), ListSortDirection.Ascending));
            }
            catch (SqlException)
            {
                MessageBox.Show("There was an error when performing this operation.\nPlease verify that all entered information is correct.\nCheck the database table DB_Errors for more information.");
            }
        }

        public void Delete()
        {
            if (_selectedEmployeeFullName != null)
            {
                var result = MessageBox.Show("Are You Sure You Want To Delete??", "Confirm Delete!!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        Employee.FullName = SelectedEmployeeFullName.FullName;

                        _validationResult = _validator.Validate(Employee);

                        if (_validationResult.IsValid == false)
                        {
                            foreach (ValidationFailure failure in _validationResult.Errors)
                            {
                                MessageBox.Show(failure.ErrorMessage);
                                return;
                            }
                        }

                        _dataAccess.DeleteNonSalesEmployee(Employee);
                        EmployeeFullNames.Remove(SelectedEmployeeFullName);
                        MessageBox.Show("Success!");
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
            else
            {
                MessageBox.Show("Must Select A Person!");
            }
        }
    }
}
