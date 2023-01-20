using AdventureWorksWPFUI.Models;
using Caliburn.Micro;

namespace AdventureWorksWPFUI.ViewModels
{
    public interface IGetNonSalesEmployeeInfoViewModel
    {
        BindableCollection<GetNonSalesEmployeeInfoModel> EmployeeInformations { get; set; }
    }
}