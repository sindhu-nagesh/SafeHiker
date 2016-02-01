using SafeHikerService.Factory;
using SafeHikerService.Models;
using SafeHikerService.TableEntities;
using Storage;
using System.Web.Http;

namespace SafeHikerService.Controllers
{
    public class UserController : ApiController
    {
        private static AzureStorageServiceClient StorageClient { get; }

        static UserController()
        {
            StorageClient = ServiceFactory.GetStorageClient();
        }

        public ReturnCode Post([FromBody] UserDataModel userData)
        {
            var userDataStorageClient = StorageClient.GetStorage(StorageType.UserData);
            var userDataEntity = new UserDataEntity(userData);
            if (userDataStorageClient.HasEntity(userDataEntity))
            {
                return ReturnCode.Duplicate;
            }

            userDataStorageClient.InsertEntity(userDataEntity);
            return ReturnCode.Success;
        }

        public ReturnCode Put([FromBody] UserDataModel userData)
        {
            var userDataStorageClient = StorageClient.GetStorage(StorageType.UserData);
            var userDataEntity = new UserDataEntity(userData);
            var retrievedEntity = userDataStorageClient.GetEntity(userDataEntity);
            if (retrievedEntity == null)
            {
                return ReturnCode.DoesNotExist;
            }

            bool result = userDataStorageClient.UpdateEntity(retrievedEntity);

            return result == true ? ReturnCode.Success : ReturnCode.Error;
        }

        public UserDataModel Get(string userId)
        {
            var partitionKey = userId;
            var userDataEntity = new UserDataEntity(userId);
            var userDataStorageClient = StorageClient.GetStorage(StorageType.UserData);
            var entity = userDataStorageClient.GetEntity(userDataEntity);

            return entity == null ? null : entity.ToUserDataModel();
        }
    }
}