using AppleStore.Service.Common.Helpers;
using AppleStore.Service.Dtos.Deliveries;
using FluentValidation;

namespace AppleStore.Service.Validators.Dtos.Deliveries;

public class DeliveryUpdateValidator : AbstractValidator<DeliveryUpdateDto>
{
    public DeliveryUpdateValidator()
    {
        RuleFor(dto => dto.FirstName).NotEmpty().NotNull().WithMessage("First name is required!")
            .MinimumLength(3).WithMessage("First name must be more than 3 characters")
            .MaximumLength(50).WithMessage("First name must be less than 50 characters");

        RuleFor(dto => dto.LastName).NotEmpty().NotNull().WithMessage("Last name is required!")
            .MinimumLength(3).WithMessage("Last name must be more than 3 characters")
            .MaximumLength(50).WithMessage("Last name must be less than 50 characters");

        RuleFor(dto => dto.PhoneNumber).NotNull().NotEmpty().WithMessage("Deliver phone number is required!")
            .Must(phone => PhoneNumberValidator.IsValid(phone)).WithMessage("Phone number is incorrect!");

        When(dto => dto.Avatar is not null, () =>
        {
            int maxImageSizeMB = 2;
            RuleFor(dto => dto.Avatar!.Length).LessThan(maxImageSizeMB * 1024 * 1024).WithMessage($"Avatar size must be less than {maxImageSizeMB} MB");
            RuleFor(dto => dto.Avatar!.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);
                return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        });
    }
}
