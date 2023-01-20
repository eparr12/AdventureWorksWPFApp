using AdventureWorksWPFClassLibrary.Models;
using AdventureWorksWPFClassLibrary.SqlDataAccess;
using AdventureWorksWPFClassLibrary.Validators;
using AdventureWorksWPFUI.ViewModels;
using Caliburn.Micro;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            _container.Instance(_container);

            _container
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IWindowManager, WindowManager>();

            _container.PerRequest<IShellViewModel, ShellViewModel>()
                .PerRequest<ILoginViewModel, LoginViewModel>()
                .PerRequest<IAddNonSalesEmployeeViewModel,AddNonSalesEmployeeViewModel>()
                .PerRequest<IDeleteNonSalesEmployeeViewModel, DeleteNonSalesEmployeeViewModel>()
                .PerRequest<IGetNonSalesEmployeeInfoViewModel, GetNonSalesEmployeeInfoViewModel>()
                .PerRequest<IUpdateNonSalesEmployeeViewModel, UpdateNonSalesEmployeeViewModel>()
                .PerRequest<IDataAccess, DataAccess>()
                .PerRequest<ILoginModel, LoginModel>()
                .PerRequest<ValidationResult>()
                .PerRequest<IValidator<ILoginModel>, LoginValidators>();
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
