using ECommerce.Core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerce.Entity.Concrete
{
    public class Product:IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }       

        public string CategoryId { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        public bool IsActive { get; set; }
    }
}
