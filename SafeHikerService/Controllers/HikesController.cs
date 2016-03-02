using SafeHikerService.Factory;
using SafeHikerService.Models;
using SafeHikerService.TableEntities;
using Storage;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SafeHikerService.Controllers
{
    public class HikesController : ApiController
    {
        private static AzureStorageServiceClient StorageClient { get; }
        private static IDataStorageService NotifyUserStorageClient { get; }
        private static IDataStorageService NotifyEmergencyStorageClient { get; }
        private static IDataStorageService UserHikeStorageClient { get; }

        static HikesController()
        {
            StorageClient = ServiceFactory.GetStorageClient();
            NotifyUserStorageClient = StorageClient.GetStorage(StorageType.NotifyUser);
            NotifyEmergencyStorageClient = StorageClient.GetStorage(StorageType.NotifyEmergency);
            UserHikeStorageClient = StorageClient.GetStorage(StorageType.UserHikesData);
        }

        // Add a hike for a user
        public ReturnCode Post(string userEmail, [FromBody] HikeDataModel hikeData)
        {
            if (NotifyUserStorageClient.HasEntity<HikeDataEntity>(hikeData.EndDateAndTime, userEmail) ||
                NotifyEmergencyStorageClient.HasEntity<HikeDataEntity>(hikeData.NotifyEmergencyContactDateAndTime, userEmail) ||
               UserHikeStorageClient.HasEntity<UserHikeEntity>(userEmail, hikeData.EndDateAndTime))
            {
                return ReturnCode.Duplicate;
            }
            NotifyUserStorageClient.InsertEntity(new NotifyUserHikeDataEntity(userEmail, hikeData));
            NotifyEmergencyStorageClient.InsertEntity(new NotifyEmergencyHikeDataEntity(userEmail, hikeData));
            var result = UserHikeStorageClient.InsertEntity(new UserHikeEntity(userEmail, hikeData, HikeStatus.Upcoming));

            return result ? ReturnCode.Success : ReturnCode.Error;
        }

        //Return all the hikes for a user
        public List<HikeDataModel> Get(string userEmail, string hikeStatus)
        {
            var partitionKey = userEmail;
            var entities = UserHikeStorageClient.GetEntities<UserHikeEntity>(partitionKey);
            return entities.Select(entity => entity.ToHikeDataModel()).ToList();
        }

        // Update a hike for a user
        public ReturnCode Put(string userEmail, [FromBody] HikeDataModel hikeData)
        {
            if (!NotifyUserStorageClient.HasEntity<HikeDataEntity>(hikeData.EndDateAndTime, userEmail) ||
                !NotifyEmergencyStorageClient.HasEntity<HikeDataEntity>(hikeData.NotifyEmergencyContactDateAndTime, userEmail) ||
               !UserHikeStorageClient.HasEntity<UserHikeEntity>(userEmail, hikeData.EndDateAndTime))
            {
                return ReturnCode.DoesNotExist;
            }
            NotifyUserStorageClient.UpdateEntity(new NotifyUserHikeDataEntity(userEmail, hikeData));
            NotifyEmergencyStorageClient.UpdateEntity(new NotifyEmergencyHikeDataEntity(userEmail, hikeData));
            var result = UserHikeStorageClient.UpdateEntity(new UserHikeEntity(userEmail, hikeData, HikeStatus.Upcoming));

            return result ? ReturnCode.Success : ReturnCode.Error;
        }
    }
}