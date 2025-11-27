using Newtonsoft.Json;

namespace IssueTracker.BusinessLayer.Services.Messaging.Models
{
    [JsonObject("pushMessageModel")]
    public class FCMPushNotificationModel
    {
        [JsonProperty("message")] public FCMPush_MessageModel PushMessage { get; set; }
    }

    [JsonObject("message")]
    public class FCMPush_MessageModel
    {
        [JsonProperty("token")] public string Token { get; set; }
        [JsonProperty("notification")] public FCMPush_NotificationModel Notification { get; set; }
    }

    [JsonObject("notification")]
    public class FCMPush_NotificationModel
    {
        [JsonProperty("body")] public string Body { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
    }
}
