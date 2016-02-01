using Microsoft.WindowsAzure.Storage.Table;
using SafeHikerService.Models;

namespace SafeHikerService.TableEntities
{
    public class HikeDataEntity : TableEntity
    {
        public string HikeName { get; set; }
        public string UserEmail { get; set; }
        public string EmergencyEmail1 { get; set; }
        public string EmergencyEmail2 { get; set; }
        public string StartDateAndTime { get; set; }
        public string EndDateAndTime { get; set; }
        public string NotifyEmergencyContactDateAndTime { get; set; }

        public HikeDataEntity()
        {
        }

        public HikeDataEntity(string userId, HikeDataModel hikeData, NotifyType notifyType)
        {
            PartitionKey = notifyType == NotifyType.NotifyUser ? EndDateAndTime : NotifyEmergencyContactDateAndTime;
            RowKey = userId;
            HikeName = hikeData.HikeName;
            UserEmail = hikeData.UserEmail;
            EmergencyEmail1 = hikeData.EmergencyEmail1;
            EmergencyEmail2 = hikeData.EmergencyEmail2;
            StartDateAndTime = hikeData.StartDateAndTime;
            EndDateAndTime = hikeData.EndDateAndTime;
            NotifyEmergencyContactDateAndTime = hikeData.NotifyEmergencyContactDateAndTime;
        }

        public HikeDataModel ToHikeDataModel()
        {
            return new HikeDataModel
            {
                HikeName = HikeName,
                EmergencyEmail1 = EmergencyEmail1,
                EmergencyEmail2 = EmergencyEmail2,
                StartDateAndTime = StartDateAndTime,
                EndDateAndTime = EndDateAndTime,
                NotifyEmergencyContactDateAndTime = NotifyEmergencyContactDateAndTime
            };
        }
    }
}