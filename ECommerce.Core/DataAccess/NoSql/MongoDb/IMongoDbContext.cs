using MongoDB.Driver;
namespace ECommerce.Core.DataAccess.NoSql.MongoDb
{
    public interface IMongoDbContext
    {
        IMongoCollection<IEntity> GetCollection<IEntity>(string name);
    }
}
