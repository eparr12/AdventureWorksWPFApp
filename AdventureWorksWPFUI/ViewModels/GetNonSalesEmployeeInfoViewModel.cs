using AdventureWorksWPFClassLibrary.Models;
using AdventureWorksWPFClassLibrary.SqlDataAccess;
using AdventureWorksWPFUI.Models;
using AutoMapper;
using Caliburn.Micro;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace AdventureWorksWPFUI.ViewModels
{
    public class GetNonSalesEmployeeInfoViewModel : Conductor<Screen>.Collection.OneActive, IGetNonSalesEmployeeInfoViewModel
    {
        private BindableCollection<GetNonSalesEmployeeInfoModel> _employeeInformations = new BindableCollection<GetNonSalesEmployeeInfoModel>();

        private IMapper _mapper;
        private IDataAccess _dataAccess;

        protected override void OnViewLoaded(object GetNonSalesInfoViewModel)
        {
            base.OnViewLoaded(GetNonSalesInfoViewModel);
            ListData();
        }

        public GetNonSalesEmployeeInfoViewModel(IMapper mapper, IDataAccess dataAccess)
        {
            _mapper = mapper;
            _dataAccess = dataAccess;
        }

        public BindableCollection<GetNonSalesEmployeeInfoModel> EmployeeInformations
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
                var Information = _dataAccess.GetNonSalesEmployeeInformation();
                var InformationData = _mapper.Map<List<GetNonSalesEmployeeInfoModel>>(Information);

                foreach (GetNonSalesEmployeeInfoModel e in InformationData)
                {
                    EmployeeInformations.Add(e);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("There was an error when performing this operation.\nPlease verify that all entered information is correct.\nCheck the database table DB_Errors for more information.");
            }
        }
    }
}
