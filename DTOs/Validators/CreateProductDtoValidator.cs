using FluentValidation;
using ProductManagement.API.DTOs.ProductDTOs;

namespace ProductManagement.API.DTOs.Validators
{
    public class CreateProductDtoValidator:AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty().WithMessage("Product Name Required")
                .MaximumLength(20).WithMessage("Max length 20");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Grater than 0");

            RuleFor(x=>x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Grater than or equal 0");
        }
    }
}
