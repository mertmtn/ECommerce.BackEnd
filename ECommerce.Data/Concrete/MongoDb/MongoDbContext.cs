using ECommerce.Core.DataAccess.NoSql.MongoDb;
using ECommerce.Data.Concrete.MongoDb.Settings; 
using Microsoft.Extensions.Options;
using MongoDB.Driver; 

namespace ECommerce.Data.Concrete.MongoDb
{
    public class MongoDbContext: IMongoDbContext
    {
        private MongoDbSettings mongoDbSettings;
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }        
        
        public MongoDbContext(IOptions<MongoDbSettings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.ConnectionString);
            _db = _mongoClient.GetDatabase(configuration.Value.Database);
        }

        public MongoDbContext(MongoDbSettings mongoDbSettings)
        {
            this.mongoDbSettings = mongoDbSettings;
            _mongoClient = new MongoClient(this.mongoDbSettings.ConnectionString);
            _db = _mongoClient.GetDatabase(this.mongoDbSettings.Database);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}
