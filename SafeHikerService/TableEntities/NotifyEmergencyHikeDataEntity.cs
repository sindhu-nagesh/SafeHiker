using SafeHikerService.Models;

namespace SafeHikerService.TableEntities
{
    public class NotifyEmergencyHikeDataEntity : HikeDataEntity
    {
        public NotifyEmergencyHikeDataEntity(string userEmail, HikeDataModel hikeData) : base(userEmail, hikeData.NotifyEmergencyContactDateAndTime, hikeData)
        {
        }
    }
}