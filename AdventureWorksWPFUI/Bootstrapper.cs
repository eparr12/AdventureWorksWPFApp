using AdventureWorksLibrary.Models;
using AdventureWorksLibrary.SqlDataAccess;
using AdventureWorksLibrary.Validators;
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
using System.Xml.Linq;

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
