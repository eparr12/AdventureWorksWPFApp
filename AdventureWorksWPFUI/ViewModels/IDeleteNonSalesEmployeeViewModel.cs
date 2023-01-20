using AdventureWorksWPFClassLibrary.Models.DropDowns;
using Caliburn.Micro;
using System.ComponentModel;

namespace AdventureWorksWPFUI.ViewModels
{
    public interface IDeleteNonSalesEmployeeViewModel
    {
        ICollectionView Collection { get; set; }
        BindableCollection<EmployeeFullNameModel> EmployeeFullNames { get; set; }
        string SearchFilter { get; set; }
        EmployeeFullNameModel SelectedEmployeeFullName { get; set; }

        void Delete();
    }
}