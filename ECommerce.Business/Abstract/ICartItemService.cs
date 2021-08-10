using ECommerce.Core;
using ECommerce.Entity.Concrete;

namespace ECommerce.Business.Abstract
{
    public interface ICartItemService
    {
        IResult Add(CartItem cartItem);
        IResult Delete(CartItem cartItem);
    }
}
