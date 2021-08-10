namespace ECommerce.Data.Concrete.MongoDb.Settings
{
    public interface IDbSettings
    {
        string ConnectionString { get; set; }
        string Database { get; set; }        
    }
}
