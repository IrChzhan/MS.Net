using BookStore.Service.Controllers.Users.Entities;
using FluentValidation;
namespace BookStore.Service.Validation;

public class UserRegisterValidator : AbstractValidator<RegisterUserRequest>
{
    public UserRegisterValidator()
    {
        RuleFor(x => x.PasswordHash)
            .NotEmpty()
            .WithMessage("Password is required");
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(200)
            .WithMessage("Name is required");
    }
        
}