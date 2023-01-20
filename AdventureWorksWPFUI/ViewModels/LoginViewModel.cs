using AdventureWorksWPFClassLibrary.Models;
using AdventureWorksWPFClassLibrary.SqlDataAccess;
using AdventureWorksWPFClassLibrary.Validators;
using Caliburn.Micro;
using FluentValidation;
using FluentValidation.Results;
using System.Data.SqlClient;
using System.Windows;

namespace AdventureWorksWPFUI.ViewModels
{
    public class LoginViewModel : Screen, ILoginViewModel
    {
        private string _loginID;
        private string _password;
        private static string role = "";

        private IEventAggregator _eventAggregator;
        private IDataAccess _dataAccess;
        private ILoginModel _loginModel;
        private ValidationResult _validationResult;
        private IValidator<ILoginModel> _validator;

        public LoginViewModel(IEventAggregator eventAggregator, IDataAccess dataAccess, ILoginModel loginModel, 
               ValidationResult validationResult, IValidator<ILoginModel> validator)
        {
            _eventAggregator = eventAggregator;
            _dataAccess = dataAccess;
            _loginModel = loginModel;
            _validationResult = validationResult;
            _validator = validator;
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

                _validationResult = _validator.Validate(_loginModel);

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
