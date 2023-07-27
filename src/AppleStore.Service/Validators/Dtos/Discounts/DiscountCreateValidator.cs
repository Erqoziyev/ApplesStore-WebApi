using AppleStore.Service.Dtos.Discounts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleStore.Service.Validators.Dtos.Discounts;

public class DiscountCreateValidator : AbstractValidator<DiscountCreateDto>
{
    public DiscountCreateValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().NotNull().WithMessage("Name is required!")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(50).WithMessage("Name must be less than 50 characters");
    }
}
