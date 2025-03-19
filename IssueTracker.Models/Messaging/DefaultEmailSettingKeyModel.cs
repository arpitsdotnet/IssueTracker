using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IssueTracker.ModelLayer.Messaging
{
    [JsonObject("EmailMessage")]
    public class DefaultEmailSettingKeyModel
    {
        [JsonProperty("Host")] public string Host { get; private set; }
        [JsonProperty("Port")] public int Port { get; private set; }
        [JsonProperty("DisplayName")] public string DisplayName { get; private set; }
        [JsonProperty("UserId")] public string UserId { get; private set; }
        [JsonProperty("Password")] public string Password { get; private set; }

        public static DefaultEmailSettingKeyModel Create(
            string Host,
            int Port,
            string DisplayName,
            string UserId,
            string Password
            ) => new DefaultEmailSettingKeyModel
            {
                Host = Host,
                Port = Port,
                DisplayName = DisplayName,
                UserId = UserId,
                Password = Password
            };
    }
}
