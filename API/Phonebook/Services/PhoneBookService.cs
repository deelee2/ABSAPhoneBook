using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using PhoneBookApi.Models;

namespace PhoneBookApi.Services
{
    public class PhoneBookService
    {
        private readonly IMongoCollection<PhoneBook> _phoneBook;

        /// <summary>
        /// Initialise Mongo database and connection
        /// </summary>
        /// <param name="settings">Object containing Mongo settings</param>
        /// <returns>An instance of PhoneBookService</returns>
        public PhoneBookService(IPhoneBookDatabaseSettings settings) {

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _phoneBook = database.GetCollection<PhoneBook>(settings.PhoneBookCollectionName);

            //If the collection and database does not exist, we will create it here and add random entries.
            //This is obviously not production worthy :)
            addRandomEntriestoDatabase();
        }

        /// <summary>
        /// General Get request returning all phone book entries
        /// </summary>
        /// <typeparam name="PhoneBook">The PhoneBook type</typeparam>
        /// <returns>A list of all phone book entries</returns>
        public List<PhoneBook> Get() => _phoneBook.Find(book => true).ToList();

        /// <summary>
        /// General Get request returning the phone book identified by the phoneBookName parameter
        /// </summary>
        /// <param name="phoneBookName">Phone Book to retrieve</param>
        /// <returns>A specific phone book entry based on the phoneBookName</returns>
        public PhoneBook Get(string phoneBookName) => _phoneBook.Find<PhoneBook>(book => book.PhoneBookName == phoneBookName).FirstOrDefault();


        /// <summary>
        /// Create a phone book entry
        /// </summary>
        /// <param name="book">Phone Book to create/param>
        /// <returns>Phone book created</returns>
        public PhoneBook Create(PhoneBook book)
        {
            _phoneBook.InsertOne(book);
            return book;
        }


        /// <summary>
        /// Add name and number to a specific phone book
        /// </summary>
        /// <param name="entry">Phone Book name and number entry/param>
        /// <returns>Object representing the added entry/returns>
        public AddEntry addEntry(AddEntry entry)
        {
            var filter = Builders<PhoneBook>.Filter.Eq("name", entry.phoneBookName);
            var update = Builders<PhoneBook>.Update.Push("entries", entry.entry);

            _phoneBook.FindOneAndUpdate(filter, update);

            return entry;
        }

        private void addRandomEntriestoDatabase()
        {
            //hack data just so we can see something on the frontend
            Random random = new Random();
            PhoneBookEntry entry = new PhoneBookEntry
            {
                Name = "First Name",
                PhoneNumber = "0823432345"
            };

            PhoneBook phoneBook = new PhoneBook
            {
                Id = ObjectId.GenerateNewId(),
                PhoneBookName = "Phone Book" + random.Next(1000),
                Entries = new List<PhoneBookEntry>() { entry }

            };

            _phoneBook.InsertOne(phoneBook);
        }

    }
}
