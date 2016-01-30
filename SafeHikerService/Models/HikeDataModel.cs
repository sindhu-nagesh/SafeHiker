namespace SafeHikerService.Models
{
    public class HikeDataModel
    {
        public string UserEmail { get; set; }
        public string HikeName { get; set; }
        public string EmergencyEmail1 { get; set; }
        public string EmergencyEmail2 { get; set; }
        public string StartDateAndTime { get; set; }
        public string EndDateAndTime { get; set; }
        public string NotifyEmergencyContactDateAndTime { get; set; }
    }
}