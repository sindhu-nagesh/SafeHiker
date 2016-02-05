using SafeHikerService.Models;
using SafeHikerService.TableEntities;

namespace Common
{
    public class StorageUtitlity
    {
        public HikeDataModel ToHikeDataModel(HikeDataEntity entity)
        {
            return new HikeDataModel
            {
                HikeName = entity.HikeName,
                EmergencyEmail1 = entity.EmergencyEmail1,
                EmergencyEmail2 = entity.EmergencyEmail2,
                StartDateAndTime = entity.StartDateAndTime,
                EndDateAndTime = entity.EndDateAndTime,
                NotifyEmergencyContactDateAndTime = entity.NotifyEmergencyContactDateAndTime
            };
        }
    }
}