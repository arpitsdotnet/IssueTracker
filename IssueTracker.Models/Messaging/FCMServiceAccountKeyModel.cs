using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IssueTracker.ModelLayer.Messaging
{
    [JsonObject("ServiceAccount")]
    public class FCMServiceAccountKeyModel
    {
        [JsonProperty("type")] public string Type { get; private set; }
        [JsonProperty("project_id")] public string ProjectId { get; private set; }
        [JsonProperty("private_key_id")] public string PrivateKeyId { get; private set; }
        [JsonProperty("private_key")] public string PrivateKey { get; private set; }
        [JsonProperty("client_email")] public string ClientEmail { get; private set; }
        [JsonProperty("client_id")] public string ClientId { get; private set; }
        [JsonProperty("auth_uri")] public string AuthUrl { get; private set; }
        [JsonProperty("token_uri")] public string TokenUrl { get; private set; }
        [JsonProperty("auth_provider_x509_cert_url")] public string AuthProviderCertUrl { get; private set; }
        [JsonProperty("client_x509_cert_url")] public string ClientCertUrl { get; private set; }
        [JsonProperty("token")] public string Token { get; private set; }

        public static FCMServiceAccountKeyModel Create(
            string Type,
            string ProjectId,
            string PrivateKeyId,
            string PrivateKey,
            string ClientEmail,
            string ClientId,
            string AuthUrl,
            string TokenUrl,
            string AuthProviderCertUrl,
            string ClientCertUrl
            ) => new FCMServiceAccountKeyModel
            {
                Type = Type,
                ProjectId = ProjectId,
                PrivateKeyId = PrivateKeyId,
                PrivateKey = PrivateKey,
                ClientEmail = ClientEmail,
                ClientId = ClientId,
                AuthUrl = AuthUrl,
                TokenUrl = TokenUrl,
                AuthProviderCertUrl = AuthProviderCertUrl,
                ClientCertUrl = ClientCertUrl
            };
    }
}
