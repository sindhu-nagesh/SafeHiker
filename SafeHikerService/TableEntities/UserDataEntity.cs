using Microsoft.WindowsAzure.Storage.Table;
using SafeHikerService.Models;

namespace SafeHikerService.TableEntities
{
    public class UserDataEntity : TableEntity
    {
        private string Name { get; }
        private string EmergencyEmail1 { get; set; }
        private string EmergencyEmail2 { get; set; }

        public UserDataEntity()
        {
        }

        public UserDataEntity(string userEmail)
        {
            PartitionKey = userEmail;
            RowKey = userEmail;
        }

        public UserDataEntity(string userEmail, UserDataModel userData)
        {
            PartitionKey = userEmail;
            RowKey = userEmail;
            Name = userData.Name;
            EmergencyEmail1 = userData.EmergencyEmail1;
            EmergencyEmail2 = userData.EmergencyEmail2;
        }

        public UserDataModel ToUserDataModel()
        {
            return new UserDataModel
            {
                Name = Name,
                EmergencyEmail1 = EmergencyEmail1,
                EmergencyEmail2 = EmergencyEmail2
            };
        }

        public void UpdateEntityData(UserDataModel userData)
        {
            EmergencyEmail1 = userData.EmergencyEmail1;
            EmergencyEmail2 = userData.EmergencyEmail2;
        }
    }
}