using Microsoft.WindowsAzure.Storage.Table;
using SafeHikerService.Models;

namespace SafeHikerService.TableEntities
{
    public class UserDataEntity : TableEntity
    {
        //public Guid UserGuid;
        //public string UserName;
        public string UserEmail;

        public string EmergencyContact1;
        public string EmergencyEmail1;
        public string EmergencyContact2;
        public string EmergencyEmail2;

        public UserDataEntity()
        {
        }

        public UserDataEntity(string userEmail)
        {
            PartitionKey = userEmail;
            RowKey = userEmail;
        }

        public UserDataEntity(UserDataModel userData)
        {
            PartitionKey = userData.UserEmail;
            RowKey = userData.UserEmail;
            EmergencyContact1 = userData.EmergencyContact1;
            EmergencyEmail1 = userData.EmergencyEmail1;
            EmergencyContact2 = userData.EmergencyContact2;
            EmergencyEmail2 = userData.EmergencyEmail2;
        }

        public UserDataModel ToUserDataModel()
        {
            return new UserDataModel
            {
                UserEmail = this.UserEmail,
                EmergencyContact1 = EmergencyContact1,
                EmergencyEmail1 = EmergencyEmail1,
                EmergencyContact2 = EmergencyContact2,
                EmergencyEmail2 = EmergencyEmail2
            };
        }
    }
}