using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Services.Messaging.Models;
using Newtonsoft.Json;

namespace IssueTracker.BusinessLayer.Utilities.MessageUtility
{
    public class FCMPushNotification : IFCMPushNotification
    {
        private readonly FCMServiceAccountKeyModel _serviceAccountKeys;

        public FCMPushNotification(FCMServiceAccountKeyModel serviceAccountKeys)
        {
            _serviceAccountKeys = serviceAccountKeys;
        }

        public async Task<ResultSingle<string>> SendAsyncActual(string fcmToken, string messageBody, string messageTitle, string messageType)
        {
            try
            {
                string serviceAccountToken = await GetServiceAccountToken(_serviceAccountKeys);

                FCMPushNotificationModel pushMessageModel = new FCMPushNotificationModel
                {
                    PushMessage = new FCMPush_MessageModel
                    {
                        Token = fcmToken,
                        Notification = new FCMPush_NotificationModel()
                        {
                            Body = messageBody,
                            Title = messageType
                        }
                    }
                };

                string json = JsonConvert.SerializeObject(pushMessageModel);

                byte[] byteArray = Encoding.UTF8.GetBytes(json);

                WebRequest webRequest = WebRequest.Create(string.Format("https://fcm.googleapis.com/v1/projects/{0}/messages:send", _serviceAccountKeys.ProjectId));
                webRequest.Method = "POST";
                webRequest.ContentType = "text/plain";
                // "application/json";
                webRequest.Headers.Add(string.Format("Authorization: Bearer {0}", serviceAccountToken));
                webRequest.ContentLength = byteArray.Length;

                using (Stream dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse webResponse = webRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = webResponse.GetResponseStream())
                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            string response = tReader.ReadToEnd();
                            return new ResultSingle<string>(true) { Message = response };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultSingle<string>(false) { Message = "Oops! Something went wrong while sending push notification.", Data = ex.Message };
            }
        }

        private async Task<string> GetServiceAccountToken(FCMServiceAccountKeyModel serviceAccount)
        {
            string[] scopes = new string[] { "https://www.googleapis.com/auth/firebase.messaging" };

            var credential = GoogleCredential.FromJson(JsonConvert.SerializeObject(serviceAccount)).CreateScoped(scopes);

            return await credential.UnderlyingCredential.GetAccessTokenForRequestAsync("https://accounts.google.com/o/oauth2/auth");
        }
    }
}
