using ECommerce.Core.DataAccess.NoSql.MongoDb;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;

namespace ECommerce.Data.Concrete.MongoDb
{
    public class MongoCategoryDal : MongoEntityRepositoryBase<Category>, ICategoryDal
    {
        public MongoCategoryDal(IMongoDbContext context) : base(context)
        {
        }

    }
}
