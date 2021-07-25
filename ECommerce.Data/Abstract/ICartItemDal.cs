using ECommerce.Core.DataAccess;
using ECommerce.Entity.Concrete;
using System;
using System.Linq.Expressions;

namespace ECommerce.Data.Abstract
{
    public interface ICartItemDal : IEntityRepository<CartItem>
    {
        
    }
}
