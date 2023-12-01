using ProductManagement.Domain.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace ProductManagement.Domain.Entities
{
    public class Product : BaseEntity
    {
        [BsonElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        [JsonProperty("description")]
        public string Description { get; set; }

        [BsonElement("price")]
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [BsonElement("color")]
        [JsonProperty("color")]
        public string Color { get; set; }

        [BsonElement("categoryId")]
        [JsonProperty("categoryId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
    }
}

