namespace PhoneBookApi.Models
{
    public class PhoneBookDatabaseSettings : IPhoneBookDatabaseSettings
    {
        public string PhoneBookCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPhoneBookDatabaseSettings
    {
        string PhoneBookCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
