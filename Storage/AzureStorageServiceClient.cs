using SafeHikerService.Models;
using Storage.impl;

namespace Storage
{
    public class AzureStorageServiceClient
    {
        private AzureDataStorageService NorifyUserStorage { get; }
        private AzureDataStorageService NotifyEmergencyStorage { get; }
        private AzureDataStorageService UserDataStorage { get; }
        private AzureDataStorageService UserHikesStorage { get; }

        public AzureStorageServiceClient(string storageAccountName, string notifyUserTableName, string notifyEmergencyTableName, string userHikesTableName, string userTableName)
        {
            NorifyUserStorage = new AzureDataStorageService(storageAccountName, notifyUserTableName);
            NotifyEmergencyStorage = new AzureDataStorageService(storageAccountName, notifyEmergencyTableName);
            UserHikesStorage = new AzureDataStorageService(storageAccountName, userHikesTableName);
            UserDataStorage = new AzureDataStorageService(storageAccountName, userTableName);
        }

        public AzureDataStorageService GetStorage(StorageType type)
        {
            switch (type)
            {
                case StorageType.NotifyUser:
                    return NorifyUserStorage;

                case StorageType.NotifyEmergency:
                    return NotifyEmergencyStorage;

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