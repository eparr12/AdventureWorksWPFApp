﻿using AdventureWorksLibrary.Models;
using AdventureWorksLibrary.Models.DropDowns;
using AdventureWorksLibrary.SqlDataAccess;
using AdventureWorksLibrary.Validators;
using Caliburn.Micro;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml.Linq;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace AdventureWorksWPFUI.ViewModels
{
    public class DeleteNonSalesEmployeeViewModel : Conductor<Screen>.Collection.OneActive
    {
        protected override void OnViewLoaded(object DeleteNonSalesInfoViewModel)
        {
            base.OnViewLoaded(DeleteNonSalesInfoViewModel);
            ListData();

        }

        private string _searchFilter = string.Empty;
        private BindableCollection<EmployeeFullNameModel> _employeeFullName = new BindableCollection<EmployeeFullNameModel>();
        private EmployeeFullNameModel _selectedPerson;

        List<EmployeeFullNameModel> Employees = new List<EmployeeFullNameModel>();
        

        public ICollectionView Collection { get; set; }

        public DeleteNonSalesEmployeeViewModel()
        {

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

        public BindableCollection<EmployeeFullNameModel> EmployeeFullName
        {
            get
            {
                return _employeeFullName;
            }
            set
            {
                _employeeFullName = value;
                NotifyOfPropertyChange(() => EmployeeFullName);
                Collection.Refresh();
            }
        }

        internal void ListData()
        {
            try
            {
                DataAccess db = new DataAccess();

                Employees = db.GetNonSalesEmployeeFullName();

                foreach (EmployeeFullNameModel e in Employees)
                {
                    EmployeeFullName.Add(e);
                }

                Collection = CollectionViewSource.GetDefaultView(_employeeFullName);

                Collection.Filter = FilterEmployees;
                Collection.SortDescriptions.Add(new SortDescription(nameof(EmployeeFullNameModel.FullName), ListSortDirection.Ascending));
            }
            catch (SqlException exception)
            {
                MessageBox.Show("There was an error when performing this operation.\nPlease verify that all entered information is correct.\nCheck the database table DB_Errors for more information.");
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

        public EmployeeFullNameModel SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public void Delete()
        {
            if (_selectedPerson != null)
            {
                var result = MessageBox.Show("Are You Sure You Want To Delete??", "Confirm Delete!!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        DataAccess db = new DataAccess();

                        EmployeeFullNameModel Employee = new EmployeeFullNameModel();
                        Employee.FullName = SelectedPerson.FullName;

                        EmployeeFullNameValidators validator = new EmployeeFullNameValidators();

                        ValidationResult results = validator.Validate(Employee);

                        if (results.IsValid == false)
                        {
                            foreach (ValidationFailure failure in results.Errors)
                            {
                                MessageBox.Show(failure.ErrorMessage);
                                return;
                            }
                        }

                        db.DeleteNonSalesEmployee(Employee);
                        EmployeeFullName.Remove(SelectedPerson);
                        MessageBox.Show("Success!");
                    }

                    catch (SqlException exception)
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
