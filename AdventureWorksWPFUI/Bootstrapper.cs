using AdventureWorksLibrary.Models;
using AdventureWorksLibrary.SqlDataAccess;
using AdventureWorksWPFUI.ViewModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AdventureWorksWPFUI
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();
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

            _container.Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();

            _container.PerRequest<ILoginModel, LoginModel>();
            _container.PerRequest<IDataAccess, DataAccess>();
            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override object GetInstance(Type service, string key)
        {
            {
                return _container.GetInstance(service, key);
            }
        }

        protected override IEnumerable<Object> GetAllInstances(Type service) 
        { 
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

  
        IDataAccess db = new DataAccess();
        ILoginModel login = new LoginModel();

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            IWindowManager manager = new WindowManager();
            manager.ShowWindowAsync(new LoginViewModel(db,login));
            DisplayRootViewForAsync<ShellViewModel>();
        }
    }
}
