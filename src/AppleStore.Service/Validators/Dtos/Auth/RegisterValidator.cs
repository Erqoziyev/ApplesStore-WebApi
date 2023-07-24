using AppleStore.Service.Dtos.Auth;
using FluentValidation;

namespace AppleStore.Service.Validators.Dtos.Auth;

public class RegisterValidator : AbstractValidator<RegistorDto>
{
    public RegisterValidator()
    {
        RuleFor(dto => dto.FirstName).NotEmpty().NotNull().WithMessage("First name is required!")
            .MaximumLength(30).WithMessage("First name must be less than 30 characters");

        RuleFor(dto => dto.LastName).NotEmpty().NotNull().WithMessage("Last name is required!")
            .MaximumLength(30).WithMessage("Last name must be less than 30 characters");

        RuleFor(dto => dto.PhoneNumber).Must(phone => PhoneNumberValidator.IsValid(phone))
            .WithMessage("Phone number is invalid! Exemple : (+998xxAAABBCC)");

        RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
            .WithMessage("Password is not strong password!");
    }
}
