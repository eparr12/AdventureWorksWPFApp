using AdventureWorksLibrary.Models;
using AdventureWorksLibrary.Models.DropDowns;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksLibrary.Validators
{
    public class EmployeeFullNameValidators : AbstractValidator<EmployeeFullNameModel>
    {
        public EmployeeFullNameValidators()
        {
            RuleFor(N => N.FullName).UniversalDropdownValidation();
        }
    }
}
