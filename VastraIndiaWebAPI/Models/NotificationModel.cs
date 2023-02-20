using Microsoft.VisualBasic;

namespace VastraIndiaWebAPI.Models
{
    public class NotificationModel
    {
        public int NotificationId { get; set; }

        public string NotificationTitle { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public string ButtonText { get; set; }
        public string ButtonUrl { get; set; }
    }
}
