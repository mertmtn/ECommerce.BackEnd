using ECommerce.Entity.Concrete;
using FluentValidation;

namespace ECommerce.Business.ValidationRules.FluentValidation
{
    public class CartItemValidator : AbstractValidator<CartItem>
    {
        public CartItemValidator()
        {
            RuleFor(c =>c.ProductId).NotEmpty().WithMessage(CartItemValidationMessage.ProductIdNotEmpty);
            RuleFor(c => c.Quantity).GreaterThanOrEqualTo(0).WithMessage(CartItemValidationMessage.QuantityNotNegative);           
        }

    }
}
