using System;
using ProductManagement.Domain.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace ProductManagement.Domain.Entities
{
    public class Category : BaseEntity
    {
        [BsonElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}

