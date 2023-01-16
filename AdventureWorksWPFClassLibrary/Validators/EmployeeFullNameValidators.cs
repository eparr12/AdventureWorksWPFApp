using AdventureWorksWPFClassLibrary.Models.DropDowns;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
