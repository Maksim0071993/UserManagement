using FluentValidation;
using System;
using UserManagement.BusinessLogic.Models;
using UserManagement.DataAccess.Models;
using UserManagement.Models;

namespace UserManagement.Validation
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).Length(1, 25);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Age).InclusiveBetween(18, 60);
        }
    }
}
