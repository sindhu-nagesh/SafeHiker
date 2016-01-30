using SafeHikerService.Models;
using Storage.impl;

namespace Storage
{
    public class AzureStorageServiceClient
    {
        private AzureDataStorageService UpcomingHikeStorage { get; }
        private AzureDataStorageService CompletedHikeStorage { get; }
        private AzureDataStorageService UserDataStorage { get; }
        private AzureDataStorageService UserHikesStorage { get; }

        public AzureStorageServiceClient(string storageAccountName, string upcomingHikeTableName, string completedHikeTableName, string userHikesTableName, string userTableName)
        {
            UpcomingHikeStorage = new AzureDataStorageService(storageAccountName, upcomingHikeTableName);
            CompletedHikeStorage = new AzureDataStorageService(storageAccountName, completedHikeTableName);
            UserDataStorage = new AzureDataStorageService(storageAccountName, userTableName);
            UserDataStorage = new AzureDataStorageService(storageAccountName, userTableName);
        }

        public AzureDataStorageService GetStorage(StorageType type)
        {
            switch (type)
            {
                case StorageType.CompletedHike:
                    return CompletedHikeStorage;

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