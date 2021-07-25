using ECommerce.Core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerce.Entity.Concrete
{
    public class Category:IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }
    }
}
