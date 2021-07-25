using System;
using ECommerce.Core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerce.Entity.Concrete
{
    public class CartItem:IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CartId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
