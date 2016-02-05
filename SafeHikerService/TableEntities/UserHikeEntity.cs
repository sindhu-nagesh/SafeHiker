using Microsoft.WindowsAzure.Storage.Table;
using SafeHikerService.Models;

namespace SafeHikerService.TableEntities
{
    public class UserHikeEntity : TableEntity
    {
        private string HikeName { get; }
        private string EmergencyEmail1 { get; }
        private string EmergencyEmail2 { get; }
        private string StartDateAndTime { get; }
        private string NotifyEmergencyContactDateAndTime { get; }
        private HikeStatus Status { get; set; }

        public UserHikeEntity()
        {
        }

        public UserHikeEntity(string userEmail, HikeDataModel hikeData, HikeStatus hikeStatus)
        {
            PartitionKey = userEmail;
            RowKey = hikeData.EndDateAndTime;
            HikeName = hikeData.HikeName;
            EmergencyEmail1 = hikeData.EmergencyEmail1;
            EmergencyEmail2 = hikeData.EmergencyEmail2;
            StartDateAndTime = hikeData.StartDateAndTime;
            NotifyEmergencyContactDateAndTime = hikeData.NotifyEmergencyContactDateAndTime;
            Status = hikeStatus;
        }

        public HikeDataModel ToHikeDataModel()
        {
            return new HikeDataModel
            {
                HikeName = HikeName,
                EmergencyEmail1 = EmergencyEmail1,
                EmergencyEmail2 = EmergencyEmail2,
                StartDateAndTime = StartDateAndTime,
                EndDateAndTime = RowKey,
                NotifyEmergencyContactDateAndTime = NotifyEmergencyContactDateAndTime
            };
        }
    }
}