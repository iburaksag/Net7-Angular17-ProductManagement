using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace ProductManagement.Domain.Common
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement(Order = 0)]
        public string? Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("datecreated")]
        [JsonProperty("datecreated")]
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [BsonElement("dateupdated")]
        [JsonProperty("dateupdated")]
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? DateUpdated { get; set; }
    }
}

