using SafeHikerService.Models;
using Storage.impl;

namespace Storage
{
    public class AzureStorageServiceClient
    {
        private AzureDataStorageService UpcomingHikeStorage { get; }
        private AzureDataStorageService UserDataStorage { get; }
        private AzureDataStorageService UserHikesStorage { get; }

        public AzureStorageServiceClient(string storageAccountName, string upcomingHikeTableName, string userHikesTableName, string userTableName)
        {
            UpcomingHikeStorage = new AzureDataStorageService(storageAccountName, upcomingHikeTableName);
            UserHikesStorage = new AzureDataStorageService(storageAccountName, userHikesTableName);
            UserDataStorage = new AzureDataStorageService(storageAccountName, userTableName);
        }

        public AzureDataStorageService GetStorage(StorageType type)
        {
            switch (type)
            {
                case StorageType.UpcomingHike:
                    return UpcomingHikeStorage;

                case StorageType.UserData:
                    return UserDataStorage;

                case StorageType.UserHikesData:
                    return UserHikesStorage;

                default:
                    return null;
            }
        }
    }
}