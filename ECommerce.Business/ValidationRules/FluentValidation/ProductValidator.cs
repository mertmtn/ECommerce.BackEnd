using ECommerce.Business.Constants.Messages;
using ECommerce.Entity.Concrete;
using FluentValidation; 

namespace ECommerce.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(b => b.ProductName).NotEmpty().WithMessage(ProductValidationMessage.ProductNameNotEmpty);            
        }
    }
}
