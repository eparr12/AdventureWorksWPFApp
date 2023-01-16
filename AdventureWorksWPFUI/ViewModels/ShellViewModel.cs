using Caliburn.Micro;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AdventureWorksWPFUI.ViewModels
{
    // TODO add title in top menu bar to show which page the user is on
    public class ShellViewModel : Conductor<object>
    {
        private bool _nonSalesEmployeeMenu = true;
        public static string Role = "";

        public ShellViewModel()
        {
            ActivateItemAsync(new LoginViewModel());
            //ActivateItemAsync(new GetNonSalesEmployeeInfoViewModel());
            //ActivateItemAsync(new DeleteNonSalesEmployeeViewModel());
            //ActivateItemAsync(new AddNonSalesEmployeeViewModel());
            //ActivateItemAsync(new UpdateNonSalesEmployeeViewModel());
        }

        public static void loginViewModel_OnLoggedIn(object sender, string role)
        {
            Role = role;
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
                    ActivateItemAsync(new LoginViewModel());
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
                    ActivateItemAsync(new LoginViewModel());
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
        }

        public void DeleteNonSalesEmployeeMenu()
        {
            ActivateItemAsync(new DeleteNonSalesEmployeeViewModel());
        }

        public void AddNonSalesEmployeeMenu()
        {
            ActivateItemAsync(new AddNonSalesEmployeeViewModel());
        }

        public void UpdateNonSalesEmployeeMenu()
        {
            ActivateItemAsync(new UpdateNonSalesEmployeeViewModel());
        }


        public bool HandlerExistsFor(Type messageType)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(object subscriber, Func<Func<Task>, Task> marshal)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(object subscriber)
        {
            throw new NotImplementedException();
        }

        public Task PublishAsync(object message, Func<Func<Task>, Task> marshal, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }

    internal record struct NewStruct(object Item1, object Item2)
    {
        public static implicit operator (object, object)(NewStruct value)
        {
            return (value.Item1, value.Item2);
        }

        public static implicit operator NewStruct((object, object) value)
        {
            return new NewStruct(value.Item1, value.Item2);
        }
    }
}
