using AppleStore.Service.Dtos.Discounts;
using FluentValidation;

namespace AppleStore.Service.Validators.Dtos.Discounts;

public class DiscountUpdateValidator : AbstractValidator<DiscountUpdateDto>
{
    public DiscountUpdateValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().NotNull().WithMessage("Name is required!")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(50).WithMessage("Name must be less than 50 characters");
    }
}
