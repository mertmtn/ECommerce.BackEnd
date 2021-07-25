using ECommerce.Core;
using ECommerce.Entity.Concrete;

namespace ECommerce.Business.Abstract
{
    public interface ICartService
    {
        IResult Add(Cart cart);        
    }
}
