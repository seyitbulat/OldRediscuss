using FluentValidation;
using Rediscuss.Model.Dtos.User;
using Rediscuss.Model.Entities;

namespace Rediscuss.Business.Validators.DtoValidators
{
    public class UserValidator : AbstractValidator<UserPostDto>
    {
        public UserValidator()
        {
            RuleFor(user => user.Email).EmailAddress().WithMessage("You have to write an email");
            RuleFor(user => user.Username).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(user => user.Password).NotNull().NotEmpty().MinimumLength(3);
 
        }
    }
}
