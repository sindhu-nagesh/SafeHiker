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

        public ReturnCode Post(string userEmail, [FromBody] HikeDataModel hikeData)
        {
            var storageClient = StorageClient.GetStorage(StorageType.UpcomingHike);
            var notifyUserEntity = new HikeDataEntity(userEmail, hikeData, NotifyType.NotifyUser);
            var notifyEmergencyContactEntity = new HikeDataEntity(userEmail, hikeData, NotifyType.NotifyEmergencyContact);
            if (storageClient.HasEntity(notifyUserEntity) ||
                StorageClient.GetStorage(StorageType.UpcomingHike).HasEntity(notifyEmergencyContactEntity))
            {
                return ReturnCode.Duplicate;
            }
            storageClient.InsertEntity(notifyUserEntity);
            storageClient.InsertEntity(notifyEmergencyContactEntity);
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