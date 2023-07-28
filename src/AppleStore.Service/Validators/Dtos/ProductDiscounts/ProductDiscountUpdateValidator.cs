using AppleStore.Service.Dtos.Products;
using FluentValidation;

namespace AppleStore.Service.Validators.Dtos.ProductDiscounts;

public class ProductDiscountUpdateValidator : AbstractValidator<ProductDiscountUpdateDto>
{
    public ProductDiscountUpdateValidator()
    {
        RuleFor(dto => dto.DiscountId).NotEmpty().NotNull().WithMessage("Price field is required!")
            .GreaterThanOrEqualTo(0).WithMessage("Enter only digit");

        RuleFor(dto => dto.ProductId).NotEmpty().NotNull().WithMessage("Price field is required!")
            .GreaterThanOrEqualTo(0).WithMessage("Enter only digit");
    }
}
