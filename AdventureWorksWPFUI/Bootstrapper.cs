using AdventureWorksWPFClassLibrary.Models;
using AdventureWorksWPFClassLibrary.Models.DropDowns;
using AdventureWorksWPFClassLibrary.SqlDataAccess;
using AdventureWorksWPFClassLibrary.Validators;
using AdventureWorksWPFUI.Models;
using AdventureWorksWPFUI.Models.DropdownListsModels;
using AdventureWorksWPFUI.ViewModels;
using AutoMapper;
using Caliburn.Micro;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

///TODO Finish adjusting validators

namespace AdventureWorksWPFUI
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new ();

        public Bootstrapper()
        {
            Initialize();

            ConventionManager.AddElementConvention<PasswordBox>(
            PasswordBoxHelper.BoundPasswordProperty,
            "Password",
            "PasswordChanged");
        }

        protected override void Configure()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NonSalesEmployeeInformationModel, GetNonSalesEmployeeInfoModel>());
            var mapper = config.CreateMapper();
            _container.Instance(mapper);

            _container.Instance(_container);

            _container
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IWindowManager, WindowManager>();

            _container.PerRequest<IDataAccess, DataAccess>()
                .PerRequest<ValidationResult>()

                .PerRequest<IShellViewModel, ShellViewModel>()
                .PerRequest<ILoginViewModel, LoginViewModel>()
                .PerRequest<IAddNonSalesEmployeeViewModel, AddNonSalesEmployeeViewModel>()
                .PerRequest<IDeleteNonSalesEmployeeViewModel, DeleteNonSalesEmployeeViewModel>()
                .PerRequest<IGetNonSalesEmployeeInfoViewModel, GetNonSalesEmployeeInfoViewModel>()
                .PerRequest<IUpdateNonSalesEmployeeViewModel, UpdateNonSalesEmployeeViewModel>()

                .PerRequest<ILoginModel, LoginModel>()
                .PerRequest<IEmployeeFullNameModel, EmployeeFullNameModel>()
                .PerRequest<IGetNonSalesEmployeeInfoModel, GetNonSalesEmployeeInfoModel>()
                .PerRequest<IDropdownListsModel, DropdownListsModel>()
                .PerRequest<IAddNonSalesEmployeeModel, AddNonSalesEmployeeModel>()
                .PerRequest<IUpdateNonSalesEmployeeModel, UpdateNonSalesEmployeeModel>()
                .PerRequest<EmployeeFullNameModel>()
                .PerRequest<BindableCollection<EmployeeFullNameModel>, BindableCollection<EmployeeFullNameModel>>()
                .PerRequest<BindableCollection<StateProvinceIDModel>, BindableCollection<StateProvinceIDModel>>()
                .PerRequest<BindableCollection<DepartmentIDModel>, BindableCollection<DepartmentIDModel>>()
                .PerRequest<BindableCollection<GetNonSalesEmployeeInfoModel>, BindableCollection<GetNonSalesEmployeeInfoModel>>()
                .PerRequest<List<UpdateNonSalesEmployeeModel>, List<UpdateNonSalesEmployeeModel>>()
                .PerRequest<List<EmployeeFullNameModel>, List<EmployeeFullNameModel>>()

                .PerRequest<IValidator<ILoginModel>, LoginValidators>()
                .PerRequest<IValidator<IAddNonSalesEmployeeModel>, AddNonSalesEmployeeValidators>()
                .PerRequest<IValidator<IEmployeeFullNameModel>, EmployeeFullNameValidators>()
                .PerRequest<IValidator<IUpdateNonSalesEmployeeModel>, UpdateNonSalesEmployeeValidators>();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewForAsync<IShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service) 
        { 
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
