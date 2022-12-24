using AdventureWorksLibrary.Models;
using AdventureWorksLibrary.SqlDataAccess;
using AdventureWorksLibrary.Validators;
using Caliburn.Micro;
using FluentValidation;
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
    public class LoginViewModel : Screen
    {

        public static string role = "";

        private string _loginID;
        private string _password;

        public LoginViewModel()
        {
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
                DataAccess db = new DataAccess();

                LoginModel Login = new LoginModel();
                Login.LoginID = LoginID;
                Login.Password = Password;

                LoginValidators validator = new LoginValidators();

                ValidationResult result = validator.Validate(Login);

                if (result.IsValid == false)
                {
                    foreach (ValidationFailure failure in result.Errors)
                    {
                        MessageBox.Show(failure.ErrorMessage);
                        return;
                    }
                }
                db.Login(Login);

                role = Login.Role;

                if (Login.Role == "Wrong LoginID Or Password. Please Try Again!")
                {
                    MessageBox.Show(Login.Role);
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
