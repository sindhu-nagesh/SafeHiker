using SafeHikerService.Common;
using Storage;

namespace SafeHikerService.Factory
{
    public static class ServiceFactory
    {
        private static AzureStorageServiceClient _storageClient;

        static ServiceFactory()
        {
            _storageClient = new AzureStorageServiceClient(Constants.StorageAccountName, Constants.UpcomingHikesTableName, Constants.CompletedHikesTableName, Constants.UserHikesTableName, Constants.UserTableName);
        }

        public static AzureStorageServiceClient GetStorageClient()
        {
            return _storageClient;
        }
    }
}