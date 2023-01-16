using AdventureWorksWPFUI.ViewModels;
using Caliburn.Micro;
using System.Windows;
using System.Windows.Controls;

namespace AdventureWorksWPFUI
{
    public class Bootstrapper : BootstrapperBase
    {

        public Bootstrapper()
        {
            Initialize();

            ConventionManager.AddElementConvention<PasswordBox>(
            PasswordBoxHelper.BoundPasswordProperty,
            "Password",
            "PasswordChanged");
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewForAsync<ShellViewModel>();
            //DisplayRootViewForAsync<GetNonSalesEmployeeInfoViewModel>();
        }
    }
}
