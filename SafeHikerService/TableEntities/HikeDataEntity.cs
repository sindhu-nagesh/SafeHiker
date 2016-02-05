using Microsoft.WindowsAzure.Storage.Table;
using SafeHikerService.Models;

namespace SafeHikerService.TableEntities
{
    public class HikeDataEntity : TableEntity
    {
        private string HikeName { get; set; }
        private string EmergencyEmail1 { get; set; }
        private string EmergencyEmail2 { get; set; }
        private string StartDateAndTime { get; set; }
        private string EndDateAndTime { get; set; }
        private string NotifyEmergencyContactDateAndTime { get; set; }

        public HikeDataEntity()
        {
        }

        public HikeDataEntity(string userEmail, string notifyTime, HikeDataModel hikeData)
        {
            PartitionKey = notifyTime;
            RowKey = userEmail;
            HikeName = hikeData.HikeName;
            EmergencyEmail1 = hikeData.EmergencyEmail1;
            EmergencyEmail2 = hikeData.EmergencyEmail2;
            StartDateAndTime = hikeData.StartDateAndTime;
            EndDateAndTime = hikeData.EndDateAndTime;
            NotifyEmergencyContactDateAndTime = hikeData.NotifyEmergencyContactDateAndTime;
        }
    }
}