using AdventureWorksLibrary.Models;
using AdventureWorksLibrary.SqlDataAccess;
using AdventureWorksLibrary.Validators;
using Caliburn.Micro;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdventureWorksWPFUI.ViewModels
{
    public class LoginViewModel : Screen
    {

        public static string role;

        private string _loginID;
        private string _password;
        IDataAccess _dataAccess;
        ILoginModel _loginModel;

        public LoginViewModel(IDataAccess dataAccess, ILoginModel loginModel)
        {
            _dataAccess = dataAccess;
            _loginModel = loginModel;
        }

        public string LoginID
        {
            get
            {
                return _loginID;
            }
            set
            {
                _loginID = value;
                NotifyOfPropertyChange(() => LoginID);
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        public void Login()
        {
            try
            {
                _loginModel.LoginID = LoginID;
                _loginModel.Password = Password;

                LoginValidators validator = new LoginValidators();

                ValidationResult result = validator.Validate(_loginModel);

                if (result.IsValid == false)
                {
                    foreach (ValidationFailure failure in result.Errors)
                    {
                        MessageBox.Show(failure.ErrorMessage);
                        return;
                    }
                }
                _dataAccess.Login(_loginModel);

                role = _loginModel.Role;

                if (_loginModel.Role == "Wrong LoginID Or Password. Please Try Again!")
                {
                    MessageBox.Show(_loginModel.Role);
                    return;
                }
                else
                {
                    this.TryCloseAsync();
                }
            }

            catch (SqlException exception)
            {
                MessageBox.Show("There was an error when performing this operation.\nPlease verify that all entered information is correct.\nCheck the database table DB_Errors for more information.");
            }
        }
    }
}
