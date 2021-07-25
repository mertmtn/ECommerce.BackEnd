using ECommerce.Core.DataAccess.NoSql.MongoDb;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete; 

namespace ECommerce.Data.Concrete.MongoDb
{
    public class MongoProductDal : MongoEntityRepositoryBase<Product>, IProductDal
    {

        public MongoProductDal(IMongoDbContext context) : base(context)
        {

        }
        
    }
}
