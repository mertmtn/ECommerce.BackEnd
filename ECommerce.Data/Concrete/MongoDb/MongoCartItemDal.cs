using ECommerce.Core.DataAccess.NoSql.MongoDb;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;
using System;
using System.Linq.Expressions;

namespace ECommerce.Data.Concrete.MongoDb
{
    public class MongoCartItemDal : MongoEntityRepositoryBase<CartItem>, ICartItemDal
    {
        public MongoCartItemDal(IMongoDbContext context) : base(context)
        {

        }
 
 
    }
}
