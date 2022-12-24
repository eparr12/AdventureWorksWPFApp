using AdventureWorksLibrary.Models;
using AdventureWorksLibrary.SqlDataAccess;
using AdventureWorksLibrary.Validators;
using Caliburn.Micro;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdventureWorksWPFUI.ViewModels
{
    public class LoginViewModel : Screen, ILoginViewModel
    {

        public static string role = "";

        private string _loginID;
        private string _password;
        IDataAccess _dataAccess;
        ILoginModel _loginModel;
        LoginValidators _loginValidators;
        ValidationResult _validationResult;

        public LoginViewModel(IDataAccess dataAccess, ILoginModel loginModel, LoginValidators loginValidators, ValidationResult validationResult)
        {
            _dataAccess = dataAccess;
            _loginModel = loginModel;
            _loginValidators = loginValidators;
            _validationResult = validationResult;
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

                _validationResult = _loginValidators.Validate(_loginModel);

                if (_validationResult.IsValid == false)
                {
                    foreach (ValidationFailure failure in _validationResult.Errors)
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
