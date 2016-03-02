using SafeHikerService.Models;

namespace SafeHikerService.TableEntities
{
    public class NotifyUserHikeDataEntity : HikeDataEntity
    {
        public NotifyUserHikeDataEntity(string userEmail, HikeDataModel hikeData) : base(userEmail, hikeData.EndDateAndTime, hikeData)
        {
        }
    }
}