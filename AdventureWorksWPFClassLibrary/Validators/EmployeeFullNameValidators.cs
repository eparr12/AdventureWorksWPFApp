using AdventureWorksWPFClassLibrary.Models.DropDowns;
using FluentValidation;

namespace AdventureWorksWPFClassLibrary.Validators
{
    public class EmployeeFullNameValidators : AbstractValidator<IEmployeeFullNameModel>
    {
        public EmployeeFullNameValidators()
        {
            RuleFor(N => N.FullName).UniversalDropdownValidation();
        }
    }
}
