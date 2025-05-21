using FluentValidation;
using ProductManagement.API.DTOs.CategoryDTOs;

namespace ProductManagement.API.DTOs.Validators
{
    public class CreateCategoryDtoValidator:AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category Name Riquire");
        }
    }

}
