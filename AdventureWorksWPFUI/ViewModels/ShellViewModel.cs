using Caliburn.Micro;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AdventureWorksWPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<string>
    {
        private bool _permissions = false;
        private readonly IEventAggregator _eventAggregator = new EventAggregator();
        private bool _menuActivation = false;
        private string _title;

        private static string role = "";

        public ShellViewModel()
        {
            Title = "Login";
            _eventAggregator.SubscribeOnPublishedThread(this);
            ActivateItemAsync(new LoginViewModel(_eventAggregator));
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
                    ActivateItemAsync(new LoginViewModel(_eventAggregator));
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
                    ActivateItemAsync(new LoginViewModel(_eventAggregator));
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
            ActivateItemAsync(new GetNonSalesEmployeeInfoViewModel());
            Title = "Non-Sales Employees Information";
        }

        public void DeleteNonSalesEmployeeMenu()
        {
            ActivateItemAsync(new DeleteNonSalesEmployeeViewModel());
            Title = "Delete Non-Sales Employees";
        }

        public void AddNonSalesEmployeeMenu()
        {
            ActivateItemAsync(new AddNonSalesEmployeeViewModel());
            Title = "Add Non-Sales Employees";
        }

        public void UpdateNonSalesEmployeeMenu()
        {
            ActivateItemAsync(new UpdateNonSalesEmployeeViewModel());
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

            ActivateItemAsync(new GetNonSalesEmployeeInfoViewModel());
            Title = "Non-Sales Employees Information";

            return Task.CompletedTask;
        }
    }
}
