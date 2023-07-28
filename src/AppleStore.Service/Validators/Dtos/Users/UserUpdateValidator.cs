using AppleStore.Service.Common.Helpers;
using AppleStore.Service.Dtos.Users;
using FluentValidation;

namespace AppleStore.Service.Validators.Dtos.Users;

public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
{
    public UserUpdateValidator()
    {
        RuleFor(dto => dto.FirstName).NotEmpty().NotNull().WithMessage("First name is required!")
            .MaximumLength(30).WithMessage("First name must be less than 30 characters");

        RuleFor(dto => dto.LastName).NotEmpty().NotNull().WithMessage("Last name is required!")
            .MaximumLength(30).WithMessage("Last name must be less than 30 characters");

        RuleFor(dto => dto.PhoneNumber).Must(phone => PhoneNumberValidator.IsValid(phone))
            .WithMessage("Phone number is invalid! Exemple : (+998xxAAABBCC)");

        RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
            .WithMessage("Password is not strong password!");

        RuleFor(dto => dto.PassportSeria).NotEmpty().NotNull().WithMessage("Passport seria number is required!")
            .MaximumLength(9).WithMessage("Passport seria number must be less than 9 characters! Exemple: AB1234567 ");

        When(dto => dto.Image is not null, () =>
        {
            int maxImageSizeMB = 3;
            RuleFor(dto => dto.Image!.Length).LessThan(maxImageSizeMB * 1024 * 1024 + 1).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
            RuleFor(dto => dto.Image!.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);
                return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        });
    }
}
