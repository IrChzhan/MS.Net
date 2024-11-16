using FluentValidation;
using BookStore.Service.Controllers.Users.Entities;


namespace BookStore.Service.Validator;

public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserRequestValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty()
            .Matches(@"[\w_]+")
            .WithMessage("Login is required");

        RuleFor(x => x.PasswordHash)
            .NotEmpty()
            .WithMessage("Password is required");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Matches("[+]7[0-9]{10}")
            .WithMessage("PhoneNumber is required");

        RuleFor(x => x.Name)
            .NotEmpty()
            .Matches("^[a-zA-Zа-яА-ЯёЁ]+$")
            .WithMessage("Name is required");

        RuleFor(x => x.Surname)
            .NotEmpty()
            .Matches("^[a-zA-Zа-яА-ЯёЁ]+$")
            .WithMessage("Surname is required");

        RuleFor(x => x.Patronymic)
            .Matches("^[a-zA-Zа-яА-ЯёЁ]+$")
            .WithMessage("Patronymic is required");
        
        RuleFor(x => x.PermissionId)
            .NotEmpty()
            .WithMessage("Permission is required");
    }
}