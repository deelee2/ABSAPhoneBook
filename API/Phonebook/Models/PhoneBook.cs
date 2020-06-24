using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PhoneBookApi.Models
{
    public class PhoneBook
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string PhoneBookName { get; set; }

        [BsonElement("entries")]
        public List<PhoneBookEntry> Entries { get; set; }
    }
}
