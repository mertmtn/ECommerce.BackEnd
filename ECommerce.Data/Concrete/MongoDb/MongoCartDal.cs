using ECommerce.Core.DataAccess.NoSql.MongoDb;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;

namespace ECommerce.Data.Concrete.MongoDb
{
    public class MongoCartDal : MongoEntityRepositoryBase<Cart>, ICartDal
    {
        public MongoCartDal(IMongoDbContext context) : base(context)
        {

        }        
    }
}
