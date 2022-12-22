using AdventureWorksLibrary.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksLibrary.Validators
{
    public class LoginValidators : AbstractValidator<ILoginModel>
    {
        public LoginValidators() 
        {
            RuleFor(N => N.Password).UniversalValidation();
            RuleFor(N => N.LoginID).UniversalValidation();
        }
    }
}
