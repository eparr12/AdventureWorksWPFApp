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
        private string _loginID;
        private string _password;

        public static string role = "";

        DataAccess db = new DataAccess();
        LoginModel login = new LoginModel();
        LoginValidators validator = new LoginValidators();

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
                login.LoginID = LoginID;
                login.Password = Password;

                ValidationResult result = validator.Validate(login);

                if (result.IsValid == false)
                {
                    foreach (ValidationFailure failure in result.Errors)
                    {
                        MessageBox.Show(failure.ErrorMessage);
                        return;
                    }
                }
                db.Login(login);

                role = login.Role;

                if (login.Role == "Wrong LoginID Or Password. Please Try Again!")
                {
                    MessageBox.Show(login.Role);
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
