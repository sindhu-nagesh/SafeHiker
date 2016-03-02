using SafeHikerService.Factory;
using SafeHikerService.Models;
using SafeHikerService.TableEntities;
using Storage;
using System.Web;
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

        // Add user data for a user
        public ReturnCode Post(string userEmail, [FromBody] UserDataModel userData)
        {
            var userDataStorageClient = StorageClient.GetStorage(StorageType.UserData);
            if (userDataStorageClient.HasEntity<UserDataEntity>(userEmail))
            {
                return ReturnCode.Duplicate;
            }
            var userDataEntity = new UserDataEntity(userEmail, userData);
            var result = userDataStorageClient.InsertEntity(userDataEntity);
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            return result ? ReturnCode.Success : ReturnCode.Error;
        }

        // Update user data for a user
        public ReturnCode Put(string userEmail, [FromBody] UserDataModel userData)
        {
            var userDataStorageClient = StorageClient.GetStorage(StorageType.UserData);
            var userDataEntity = userDataStorageClient.GetEntity(new UserDataEntity(userEmail));
            if (userDataEntity == null)
            {
                return ReturnCode.DoesNotExist;
            }
            userDataEntity.UpdateEntityData(userData);
            bool result = userDataStorageClient.UpdateEntity(userDataEntity);
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            return result ? ReturnCode.Success : ReturnCode.Error;
        }

        // Ger user data for a user
        public UserDataModel Get(string userEmail)
        {
            var userDataEntity = new UserDataEntity(userEmail);
            var userDataStorageClient = StorageClient.GetStorage(StorageType.UserData);
            var entity = userDataStorageClient.GetEntity(userDataEntity);
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            return entity == null ? new UserDataModel() : entity.ToUserDataModel();
        }

        public void Options()
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST, GET, DELETE, OPTIONS, PUT");
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type");
        }
    }
}