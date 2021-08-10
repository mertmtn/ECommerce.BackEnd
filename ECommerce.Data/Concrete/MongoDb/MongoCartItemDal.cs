using ECommerce.Core.DataAccess.NoSql.MongoDb;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;

namespace ECommerce.Data.Concrete.MongoDb
{
    public class MongoCartItemDal : MongoEntityRepositoryBase<CartItem>, ICartItemDal
    {
        public MongoCartItemDal(IMongoDbContext context) : base(context)
        {

        }
    }
}
