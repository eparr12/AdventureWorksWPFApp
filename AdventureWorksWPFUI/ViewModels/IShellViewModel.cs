using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksWPFUI.ViewModels
{
    public interface IShellViewModel
    {
        bool MenuActivation { get; set; }
        bool Permissions { get; set; }
        string Title { get; set; }

        void AddNonSalesEmployeeMenu();
        void DeleteNonSalesEmployeeMenu();
        Task HandleAsync(string message, CancellationToken cancellationToken);
        void LogOut();
        void NonSalesEmployeeInfoMenu();
        void UpdateNonSalesEmployeeMenu();
    }
}