using Storage.impl;

namespace Storage
{
    public class AzureStorageServiceClient
    {
        public AzureDataStorageService HikeStorage { get; set; }

        public AzureDataStorageService UserStorage { get; set; }

        public AzureStorageServiceClient(string storageAccountName, string hikeTableName, string userTableName)
        {
            HikeStorage = new AzureDataStorageService(storageAccountName, hikeTableName);
            UserStorage = new AzureDataStorageService(storageAccountName, userTableName);
        }
    }
}