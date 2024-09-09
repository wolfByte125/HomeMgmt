using HomeMgmt.Models.NotificationModels;

namespace HomeMgmt.DTOs.NotificationDTOs
{
    public class NotificationsAndCountReturnDTO
    {
        public List<Notification> Notifications { get; set; } = new();

        public int Count { get; set; }
    }
}
