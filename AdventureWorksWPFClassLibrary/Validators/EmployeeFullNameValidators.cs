using AdventureWorksWPFClassLibrary.Models.DropDowns;
using FluentValidation;

namespace AdventureWorksWPFClassLibrary.Validators
{
    public class EmployeeFullNameValidators : AbstractValidator<EmployeeFullNameModel>
    {
        public EmployeeFullNameValidators()
        {
            RuleFor(N => N.FullName).UniversalDropdownValidation();
        }
    }
}
