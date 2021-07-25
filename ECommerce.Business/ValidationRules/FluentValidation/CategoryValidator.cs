using ECommerce.Business.Constants.Validation;
using ECommerce.Entity.Concrete;
using FluentValidation;

namespace ECommerce.Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c =>c.CategoryName).NotEmpty().WithMessage(CategoryValidationMessage.CategoryNameNotEmpty);
        }
    }
}
