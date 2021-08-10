using ECommerce.Business.Abstract;
using ECommerce.Business.Constants.Messages;
using ECommerce.Business.ValidationRules.FluentValidation;
using ECommerce.Core;
using ECommerce.Core.Aspects.Autofac.ValidationAspect;
using ECommerce.Core.Error;
using ECommerce.Core.Success;
using ECommerce.Core.Utilities.Business;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;
using System.Linq.Expressions;

namespace ECommerce.Business.Concrete
{
    public class CartItemManager : ICartItemService
    {
        private ICartItemDal _cartItemDal;
        private IProductService _productService;
        public CartItemManager(ICartItemDal cartItemDal, IProductService productService)
        {
            _cartItemDal = cartItemDal;
            _productService = productService;           
        }

        [ValidationAspect(typeof(CartItemValidator), Priority = 1)]
        public IResult Add(CartItem cartItem)
        {            
            IResult result = BusinessRules.Run(CheckProductStock(cartItem));
            if (result != null)
            {
                return result;
            }
             
            var existingCartItem = _cartItemDal.Get(c => c.ProductId == cartItem.ProductId && c.CartId == cartItem.CartId);
            if (existingCartItem != null)
            {
                cartItem.Id = existingCartItem.Id;
                cartItem.CartId = existingCartItem.CartId;

                Expression<System.Func<CartItem, bool>> updateFilterExpression = c => c.ProductId == cartItem.ProductId && c.CartId == cartItem.CartId && c.Id == cartItem.Id;

                _cartItemDal.Update(cartItem, updateFilterExpression);
            }
            else
            {                
                _cartItemDal.Add(cartItem);
            }
            return new SuccessResult(CartItemMessage.CartItemAddedSuccessfully);
        }

        public IResult Delete(CartItem cartItem)
        {
            Expression<System.Func<CartItem, bool>> deleteFilterExpression = c => c.ProductId == cartItem.ProductId && c.CartId == cartItem.CartId;
            
            _cartItemDal.Delete(cartItem, deleteFilterExpression);
            return new SuccessResult(CartItemMessage.CartItemDeletedSuccessfully);
        }

        private IResult CheckProductStock(CartItem cartItem)
        {
            var product = _productService.GetById(cartItem.ProductId);
            if (product.Data != null && product.Data.UnitsInStock > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult(ProductMessage.ProductIsNotInStock);
        }
    }
}
