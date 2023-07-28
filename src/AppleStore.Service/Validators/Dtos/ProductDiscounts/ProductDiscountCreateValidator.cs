using AppleStore.Service.Dtos.Products;
using FluentValidation;

namespace AppleStore.Service.Validators.Dtos.ProductDiscounts;

public class ProductDiscountCreateValidator : AbstractValidator<ProductDiscountCreateDto>
{
    public ProductDiscountCreateValidator()
    {
        RuleFor(dto => dto.ProductId).NotEmpty().NotNull().WithMessage("Price field is required!")
            .GreaterThanOrEqualTo(0).WithMessage("Enter only digit");

        RuleFor(dto => dto.DiscountId).NotEmpty().NotNull().WithMessage("Price field is required!")
            .GreaterThanOrEqualTo(0).WithMessage("Enter only digit");

        

    }
}
