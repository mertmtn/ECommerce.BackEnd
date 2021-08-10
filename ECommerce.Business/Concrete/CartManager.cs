using ECommerce.Business.Abstract;
using ECommerce.Core;
using ECommerce.Core.Success;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;  

namespace ECommerce.Business.Concrete
{
    public class CartManager : ICartService
    {
        private ICartDal _cartDal;  
        public CartManager(ICartDal cartItem)
        {
            _cartDal = cartItem; 
        }
        public IResult Add(Cart cart)
        {
            _cartDal.Add(cart);
            return new SuccessResult();
        }  
    }
}
