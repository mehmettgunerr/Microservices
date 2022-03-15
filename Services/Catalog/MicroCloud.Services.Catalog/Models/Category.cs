using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroCloud.Services.Catalog.Models
{
    public class Category
    {
        [BsonId] //mongo db id
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
