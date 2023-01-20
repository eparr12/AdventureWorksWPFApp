﻿using AdventureWorksWPFClassLibrary.Models;
using AdventureWorksWPFClassLibrary.SqlDataAccess;
using AdventureWorksWPFClassLibrary.Validators;
using Caliburn.Micro;
using FluentValidation.Results;
using System.Data.SqlClient;
using System.Windows;

namespace AdventureWorksWPFUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _loginID;
        private string _password;
        private IEventAggregator _eventAggregator;

        private static string role = "";

        DataAccess db = new DataAccess();
        LoginModel login = new LoginModel();
        LoginValidators validator = new LoginValidators();

        public LoginViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
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
                    _eventAggregator.PublishOnUIThreadAsync(role);
                    this.TryCloseAsync();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("There was an error when performing this operation.\nPlease verify that all entered information is correct.\nCheck the database table DB_Errors for more information.");
            }
        }
    }
}
