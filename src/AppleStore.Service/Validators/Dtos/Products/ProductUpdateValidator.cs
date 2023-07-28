using AppleStore.Service.Common.Helpers;
using AppleStore.Service.Dtos.Products;
using FluentValidation;

namespace AppleStore.Service.Validators.Dtos.Products;

public class ProductUpdateValidator : AbstractValidator<ProductUpdateDto>
{
    public ProductUpdateValidator()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name field is required!")
            .MinimumLength(2).WithMessage("Name must be more than 3 characters")
            .MaximumLength(50).WithMessage("Name must be less than 50 characters");

        RuleFor(dto => dto.Price).NotEmpty().NotNull().WithMessage("Price field is required!")
            .GreaterThanOrEqualTo(0).WithMessage("Yaxshimisiz. To'y qachon to'y");

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
