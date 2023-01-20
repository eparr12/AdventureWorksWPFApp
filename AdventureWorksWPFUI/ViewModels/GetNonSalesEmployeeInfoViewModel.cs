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

        List<GetNonSalesEmployeeInfoModel> Information = new List<GetNonSalesEmployeeInfoModel>();

        DataAccess db = new DataAccess();

        protected override void OnViewLoaded(object GetNonSalesInfoViewModel)
        {
            base.OnViewLoaded(GetNonSalesInfoViewModel);
            ListData();
        }

        public GetNonSalesEmployeeInfoViewModel()
        {
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
                var config = new MapperConfiguration(cfg => cfg.CreateMap<NonSalesEmployeeInformationModel, GetNonSalesEmployeeInfoModel>());
                var mapper = new Mapper(config);
                var Information = db.GetNonSalesEmployeeInformation();
                var InformationData = mapper.Map<List<GetNonSalesEmployeeInfoModel>>(Information);

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
