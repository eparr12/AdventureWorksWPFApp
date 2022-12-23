using AdventureWorksLibrary.Models;
using AdventureWorksLibrary.SqlDataAccess;
using AdventureWorksLibrary.Validators;
using AdventureWorksWPFUI.Views;
using Caliburn.Micro;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace AdventureWorksWPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        IDataAccess _dataAccess;
        ILoginModel _loginModel;

        public ShellViewModel(IDataAccess dataAccess,ILoginModel loginModel) 
        {
            _dataAccess = dataAccess;
            _loginModel = loginModel;
            ActivateItemAsync(new LoginViewModel(_dataAccess,_loginModel));
        }

        public void LogOut()
        {
            if (LoginViewModel.role == "Administrator")
            {
                var confirmResult = MessageBox.Show($"Are You Sure You Want To LogOut?",
             "Confirm LogOut.", MessageBoxButton.YesNo);
                if (confirmResult == MessageBoxResult.Yes)
                {
                    LoginViewModel.role = "";
                    ActivateItemAsync(new LoginViewModel(_dataAccess, _loginModel));
                }
                else
                {
                    return;
                }
             
            }

            if (LoginViewModel.role == "Basic")
            {
                var confirmResult = MessageBox.Show($"Are You Sure You Want To LogOut?",
             "Confirm LogOut.", MessageBoxButton.YesNo);
                if (confirmResult == MessageBoxResult.Yes)
                {
                    LoginViewModel.role = "";
                    ActivateItemAsync(new LoginViewModel(_dataAccess, _loginModel));
                }
                else
                {
                    return;
                }

            }
            else
            {
                return;
            }
        }

    }
}
