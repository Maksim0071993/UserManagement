using FluentValidation;
using UserManagement.BusinessLogic.Models;
using UserManagement.Models;

namespace UserManagement.Validation
{
    public class RoleValidator : AbstractValidator<RoleViewModel>
    {
        public RoleValidator()
        {
            RuleFor(x => x.RoleName).Length(4, 10);
        }
    }
}
