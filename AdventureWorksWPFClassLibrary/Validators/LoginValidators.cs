using AdventureWorksWPFClassLibrary.Models;
using FluentValidation;

namespace AdventureWorksWPFClassLibrary.Validators
{
    public class LoginValidators : AbstractValidator<LoginModel>
    {
        public LoginValidators()
        {
            RuleFor(N => N.Password).UniversalValidation();
            RuleFor(N => N.LoginID).UniversalValidation();
        }
    }
}
