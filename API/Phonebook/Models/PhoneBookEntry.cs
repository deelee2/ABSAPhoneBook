using MongoDB.Bson.Serialization.Attributes;

namespace PhoneBookApi.Models
{
    public class PhoneBookEntry
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
