using SafeHikerService.Factory;
using SafeHikerService.Models;
using SafeHikerService.TableEntities;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SafeHikerService.Controllers
{
    public class HikesController : ApiController
    {
        private static AzureStorageServiceClient StorageClient { get; }

        static HikesController()
        {
            StorageClient = ServiceFactory.GetStorageClient();
        }

        public ReturnCode Post(string userId, [FromBody] HikeDataModel hikeData)
        {
            var hikeDataStorageClient = StorageClient.GetStorage(StorageType.UpcomingHike);
            var userHikeStorageClient = StorageClient.GetStorage(StorageType.UserHikesData);
            var notifyUserEntity = new HikeDataEntity(userId, hikeData, NotifyType.NotifyUser);
            var notifyEmergencyContactEntity = new HikeDataEntity(userId, hikeData, NotifyType.NotifyEmergencyContact);
            var userHikeEntity = new UserHikeEntity(userId, HikeStatus.Upcoming, hikeData);
            if (hikeDataStorageClient.HasEntity(notifyUserEntity) ||
                hikeDataStorageClient.HasEntity(notifyEmergencyContactEntity) ||
               userHikeStorageClient.HasEntity(userHikeEntity))
            {
                return ReturnCode.Duplicate;
            }
            hikeDataStorageClient.InsertEntity(notifyUserEntity);
            hikeDataStorageClient.InsertEntity(notifyEmergencyContactEntity);
            userHikeStorageClient.InsertEntity(userHikeEntity);
            return ReturnCode.Success;
        }

        public List<HikeDataModel> Get(string userId, string type)
        {
            var partitionKey = userId + " " + type;
            var storageType = (StorageType)Enum.Parse(typeof(StorageType), type);
            var entities = StorageClient.GetStorage(storageType).GetEntities<HikeDataEntity>(partitionKey);
            return entities.Select(entity => entity.ToHikeDataModel()).ToList();
        }
    }
}