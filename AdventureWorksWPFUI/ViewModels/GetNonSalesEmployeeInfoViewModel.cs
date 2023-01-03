using AdventureWorksLibrary.Models;
using AdventureWorksLibrary.Models.DropDowns;
using AdventureWorksLibrary.SqlDataAccess;
using Caliburn.Micro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AdventureWorksWPFUI.ViewModels
{
    public class GetNonSalesEmployeeInfoViewModel : Conductor<Screen>.Collection.OneActive
    {

        private string _selectedInformation = string.Empty;
        private BindableCollection<NonSalesEmployeeInformationModel> _employeeInformations = new BindableCollection<NonSalesEmployeeInformationModel>();

        List<NonSalesEmployeeInformationModel> Information = new List<NonSalesEmployeeInformationModel>();

        DataAccess db = new DataAccess();

        public ICollectionView Collection { get; set; }

        protected override void OnViewLoaded(object GetNonSalesInfoViewModel)
        {
            base.OnViewLoaded(GetNonSalesInfoViewModel);
            ListData();

        }

        public GetNonSalesEmployeeInfoViewModel()
        { 

        }

        public string SelectedInformation
        {
            get
            {
                return _selectedInformation;
            }
            set
            {
                _selectedInformation = value;
                NotifyOfPropertyChange(() => SelectedInformation);
                Collection.Refresh();
            }
        }

        public BindableCollection<NonSalesEmployeeInformationModel> EmployeeInformations
        {
            get 
            {
                return _employeeInformations;
            }
            set
            {
                _employeeInformations = value;
            }
        }

        internal void ListData()
        {
            try
            {
                Information = db.GetNonSalesEmployeeInformation();

                foreach (NonSalesEmployeeInformationModel e in Information)
                {
                    EmployeeInformations.Add(e);
                }

                Collection = CollectionViewSource.GetDefaultView(_employeeInformations);

                Collection.Filter = FilterEmployees;
                Collection.GroupDescriptions.Add(new PropertyGroupDescription(nameof(NonSalesEmployeeInformationModel.JobGroup)));
                Collection.GroupDescriptions.Add(new PropertyGroupDescription(nameof(NonSalesEmployeeInformationModel.JobDepartment)));
                Collection.GroupDescriptions.Add(new PropertyGroupDescription(nameof(NonSalesEmployeeInformationModel.JobTitle)));
                Collection.SortDescriptions.Add(new SortDescription(nameof(NonSalesEmployeeInformationModel.JobGroup), ListSortDirection.Ascending));
                Collection.SortDescriptions.Add(new SortDescription(nameof(NonSalesEmployeeInformationModel.JobDepartment), ListSortDirection.Ascending));
                Collection.SortDescriptions.Add(new SortDescription(nameof(NonSalesEmployeeInformationModel.JobTitle), ListSortDirection.Ascending));
                Collection.SortDescriptions.Add(new SortDescription(nameof(NonSalesEmployeeInformationModel.PersonName), ListSortDirection.Ascending));
            }

            catch (SqlException exception)
            {
                MessageBox.Show("There was an error when performing this operation.\nPlease verify that all entered information is correct.\nCheck the database table DB_Errors for more information.");
            }
        }

        private bool FilterEmployees(object obj)
        {
            if(obj is NonSalesEmployeeInformationModel filter) 
            {
                return filter.PersonName.Contains(SelectedInformation,StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

    }
}
