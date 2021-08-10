 namespace ECommerce.Data.Concrete.MongoDb.Settings
{
    public class MongoDbSettings : IDbSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }  
    }
}
