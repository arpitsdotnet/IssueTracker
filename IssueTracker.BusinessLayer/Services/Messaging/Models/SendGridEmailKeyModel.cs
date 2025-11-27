namespace IssueTracker.BusinessLayer.Services.Messaging.Models
{
    public class SendGridEmailKeyModel
    {
        public string EnabledYN { get; set; }
        public string ApiKey { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
    }
}
