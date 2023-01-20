using Caliburn.Micro;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AdventureWorksWPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<string>, IShellViewModel
    {
        private bool _permissions = false;
        private bool _menuActivation = false;
        private string _title;
        private static string role = "";

        private IEventAggregator _eventAggregator;
        private ILoginViewModel _loginViewModel;
        private IGetNonSalesEmployeeInfoViewModel _getNonSalesEmployeeInfoViewModel;
        private IDeleteNonSalesEmployeeViewModel _deleteNonSalesEmployeeViewModel;
        private IAddNonSalesEmployeeViewModel _addNonSalesEmployeeViewModel;
        private IUpdateNonSalesEmployeeViewModel _updateNonSalesEmployeeViewModel;

        public ShellViewModel(IEventAggregator eventAggregator, ILoginViewModel loginViewModel, 
                              IGetNonSalesEmployeeInfoViewModel getNonSalesEmployeeInfoViewModel, 
                              IDeleteNonSalesEmployeeViewModel deleteNonSalesEmployeeViewModel, 
                              IAddNonSalesEmployeeViewModel addNonSalesEmployeeViewModel,
                              IUpdateNonSalesEmployeeViewModel updateNonSalesEmployeeViewModel)
        {
            _loginViewModel = loginViewModel;
            _eventAggregator = eventAggregator;
            _getNonSalesEmployeeInfoViewModel = getNonSalesEmployeeInfoViewModel;
            _deleteNonSalesEmployeeViewModel = deleteNonSalesEmployeeViewModel;
            _addNonSalesEmployeeViewModel = addNonSalesEmployeeViewModel;
            _updateNonSalesEmployeeViewModel = updateNonSalesEmployeeViewModel;
            _eventAggregator.SubscribeOnPublishedThread(this);
            Title = "Login";
            ActivateItemAsync(_loginViewModel);
        }

        public bool MenuActivation
        {
            get
            {
                return _menuActivation;
            }
            set
            {
                _menuActivation = value;
                NotifyOfPropertyChange(() => MenuActivation);
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        public bool Permissions
        {
            get
            {
                return _permissions;
            }
            set
            {
                _permissions = value;
                NotifyOfPropertyChange(() => Permissions);
            }
        }

        public void LogOut()
        {
            if (role == "Administrator")
            {
                var confirmResult = MessageBox.Show($"Are You Sure You Want To LogOut?",
             "Confirm LogOut.", MessageBoxButton.YesNo);
                if (confirmResult == MessageBoxResult.Yes)
                {
                    MenuActivation = false;
                    role = "";
                    Title = "Login";
                    ActivateItemAsync(_loginViewModel);
                }
                else
                {
                    return;
                }

            }

            if (role == "Basic")
            {
                var confirmResult = MessageBox.Show($"Are You Sure You Want To LogOut?",
             "Confirm LogOut.", MessageBoxButton.YesNo);
                if (confirmResult == MessageBoxResult.Yes)
                {
                    MenuActivation = false;
                    role = "";
                    Title = "Login";
                    ActivateItemAsync(_loginViewModel);
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

        public void NonSalesEmployeeInfoMenu()
        {
            ActivateItemAsync(_getNonSalesEmployeeInfoViewModel);
            Title = "Non-Sales Employees Information";
        }

        public void DeleteNonSalesEmployeeMenu()
        {
            ActivateItemAsync(_deleteNonSalesEmployeeViewModel);
            Title = "Delete Non-Sales Employees";
        }

        public void AddNonSalesEmployeeMenu()
        {
            ActivateItemAsync(_addNonSalesEmployeeViewModel);
            Title = "Add Non-Sales Employees";
        }

        public void UpdateNonSalesEmployeeMenu()
        {
            ActivateItemAsync(_updateNonSalesEmployeeViewModel);
            Title = "Update Non-Sales Employees Information";
        }

        public Task HandleAsync(string message, CancellationToken cancellationToken)
        {
            MenuActivation = true;
            role = message;

            if (role == "Administrator")
            {
                Permissions = true;
            }

            else
            {
                Permissions = false;
            }

            ActivateItemAsync(_getNonSalesEmployeeInfoViewModel);
            Title = "Non-Sales Employees Information";

            return Task.CompletedTask;
        }
    }
}
