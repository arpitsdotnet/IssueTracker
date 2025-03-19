using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Utilities.MessageUtility;
using IssueTracker.ModelLayer.Base;

namespace IssueTracker.BusinessLayer.Services.Messaging
{
    public interface IMobileAppSender
    {
        ResultSingle<string> SendMobMessageClass(string GoogleAppID, string DeviceId, string msg);
        ResultSingle<string> SendMobMessageClass_SNDP(string GoogleAppID, string DeviceId, SortedList<string, string> msg);
        ResultSingle<string> SendMobMessageClass_SNDP_FB(string GoogleAppID, string DeviceId, string SenderId, SortedList<string, string> msg);
        Task<ResultSingle<string>> SendMobMessage_IOS(string GoogleAppID, string DeviceId, string SenderId, string msgbody, string msgSubjectTitle, string msgType);
        Task<ResultSingle<string>> SendMobileAppNotificationNew(string DeviceId, string msgbody, string msgSubjectTitle, string msgType);
        Task<ResultSingle<string>> SendMobileAppNotificationMultiple(List<string> DeviceIds, string msgbody, string msgSubjectTitle, string msgType);
    }

    public class MobileAppSender : IMobileAppSender
    {
        //private readonly IConfiguration _configuration;
        private readonly IFirebasePushNotification _pushNotificationSender;
        private readonly bool _sendMobileAppNotificationViaNewMethodYN;

        public MobileAppSender(IFirebasePushNotification pushNotificationSender, bool sendMobileAppNotificationViaNewMethodYN)
        {
            _pushNotificationSender = pushNotificationSender;
            _sendMobileAppNotificationViaNewMethodYN = sendMobileAppNotificationViaNewMethodYN;
        }

        public ResultSingle<string> SendMobMessageClass(string GoogleAppID, string DeviceId, string msg)
        {
            StreamReader streamReader = null;
            WebResponse webResponse = null;
            try
            {
                WebRequest webRequest;
                webRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");
                webRequest.Method = "post";
                webRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                webRequest.Headers.Add(string.Format("Authorization: key={0}", GoogleAppID));

                string collaspeKey = Guid.NewGuid().ToString("n");
                string postData = string.Format("registration_id={0}&data.msg={1}&collapse_key={2}", DeviceId, msg, collaspeKey);
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                webRequest.ContentLength = byteArray.Length;

                Stream dataStream = webRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                webResponse = webRequest.GetResponse();
                streamReader = new StreamReader(webResponse.GetResponseStream());
                string serverResponse = streamReader.ReadToEnd();
                SaveNotificationLog(GoogleAppID, DeviceId, "", serverResponse, "OK", 1, "SendMessageClass.SendMobMessageClass");

                return new ResultSingle<string>(true) { Message = "MobileApp Notification Sent Successfully.", Data = serverResponse };
            }
            catch (Exception ex)
            {
                string serverResponse = ex.Message.ToString();
                string InnerException = "";
                if (ex.InnerException != null) InnerException = ex.InnerException.ToString();
                if (InnerException != "" && InnerException.Length > 3500) InnerException = InnerException.Substring(1, 3500);

                SaveNotificationLog(GoogleAppID, DeviceId, "", serverResponse, "Error", 0, InnerException);
                return new ResultSingle<string>(false) { Message = "MobileApp Notification has not been sent, Details: " + serverResponse, Data = InnerException };
            }
            finally
            {
                streamReader.Close();
                webResponse.Close();
            }
        }

        public ResultSingle<string> SendMobMessageClass_SNDP(string GoogleAppID, string DeviceId, SortedList<string, string> msg)
        {
            StreamReader streamReader = null;
            WebResponse webResponse = null;
            try
            {
                string jsonMsg = Newtonsoft.Json.JsonConvert.SerializeObject(msg);

                WebRequest webRequest;

                webRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");
                webRequest.Method = "post";
                webRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                webRequest.Headers.Add(string.Format("Authorization: key={0}", GoogleAppID));

                string collaspeKey = Guid.NewGuid().ToString("n");
                string postData = string.Format("registration_id={0}&data.msg={1}&collapse_key={2}", DeviceId, jsonMsg, collaspeKey);
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                webRequest.ContentLength = byteArray.Length;

                Stream dataStream = webRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                webResponse = webRequest.GetResponse();
                streamReader = new StreamReader(webResponse.GetResponseStream());
                string serverResponse = streamReader.ReadToEnd();
                SaveNotificationLog(GoogleAppID, DeviceId, "", serverResponse, "OK", 1, "SendMessageClass.SendMobMessageClass_SNDP");

                return new ResultSingle<string>(true) { Message = "MobileApp Notification Sent Successfully.", Data = serverResponse };
            }
            catch (Exception ex)
            {
                string serverResponse = ex.Message.ToString();
                string InnerException = "";
                if (ex.InnerException != null) InnerException = ex.InnerException.ToString();
                if (InnerException != "" && InnerException.Length > 3500) InnerException = InnerException.Substring(1, 3500);

                SaveNotificationLog(GoogleAppID, DeviceId, "", serverResponse, "Error", 0, InnerException);
                return new ResultSingle<string>(false) { Message = "MobileApp Notification has not been sent, Details: " + serverResponse, Data = InnerException };
            }
            finally
            {
                streamReader.Close();
                webResponse.Close();
            }
        }

        public ResultSingle<string> SendMobMessageClass_SNDP_FB(string GoogleAppID, string DeviceId, string SenderId, SortedList<string, string> msg)
        {
            try
            {
                SaveNotificationLog(GoogleAppID, DeviceId, SenderId, "Step 02", "OK", 0, "SendMessageClass.SendMobMessageClass_SNDP_FB");

                //ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                //string deviceId = "APA91bF95d_d8TrVRx779KEaeMxdJPlHQuRJ4TAT3gcpctQQcfmH7rBBQsjcm_UO-AAhFMCml9BRJ4wryIdUA3S_oAVPAQUKzg1qezYSr_ATgXQssNR4ow0LdK7SCavqLRjLc24TXnSe";
                WebRequest webRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                webRequest.Method = "post";
                webRequest.ContentType = "application/json";

                var data1 = new
                {
                    to = DeviceId,
                    data = new
                    {
                        text = "text",
                        title = msg,
                        line1 = "Journal",
                        line2 = ""
                    }
                };
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data1);
                byte[] byteArray = Encoding.UTF8.GetBytes(json);

                webRequest.Headers.Add(string.Format("Authorization: key={0}", GoogleAppID));
                webRequest.Headers.Add(string.Format("Sender: id={0}", SenderId));
                webRequest.ContentLength = byteArray.Length;

                using (Stream dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse webResponse = webRequest.GetResponse())
                    {
                        using (StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
                        {
                            string serverResponse = streamReader.ReadToEnd();
                            SaveNotificationLog(GoogleAppID, DeviceId, SenderId, serverResponse, "OK", 0, "SendMessageClass.SendMobMessageClass_SNDP_FB");

                            return new ResultSingle<string>(true) { Message = "MobileApp Notification Sent Successfully.", Data = serverResponse };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string serverResponse = ex.Message.ToString();
                string InnerException = "";
                if (ex.InnerException != null) InnerException = ex.InnerException.ToString();
                if (InnerException != "" && InnerException.Length > 3500) InnerException = InnerException.Substring(1, 3500);

                SaveNotificationLog(GoogleAppID, DeviceId, SenderId, serverResponse, "Error", 0, InnerException);
                return new ResultSingle<string>(false) { Message = "MobileApp Notification has not been sent, Details: " + serverResponse, Data = InnerException };
            }
        }

        public async Task<ResultSingle<string>> SendMobMessage_IOS(string GoogleAppID, string DeviceId, string SenderId, string msgbody, string msgSubjectTitle, string msgType)
        {
            try
            {
                if (_sendMobileAppNotificationViaNewMethodYN == true)
                    return await SendMobileAppNotificationNew(DeviceId, msgbody, msgSubjectTitle, msgType);

                //ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                WebRequest webRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                webRequest.Method = "post";
                webRequest.ContentType = "application/json";

                var data = new
                {
                    to = DeviceId,
                    notification = new
                    {
                        body = msgbody,
                        title = msgSubjectTitle,
                        icon = "myicon",
                        subtitle = msgType
                    },
                    //////// added on 10-Mar-21 for React Native code get alertType(MsgType)
                    data = new
                    {
                        body = msgbody,
                        title = msgSubjectTitle,
                        icon = "myicon",
                        MsgType = msgType
                    }
                };

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                byte[] byteArray = Encoding.UTF8.GetBytes(json);
                webRequest.Headers.Add(string.Format("Authorization: key={0}", GoogleAppID));
                webRequest.Headers.Add(string.Format("Sender: id={0}", SenderId));
                webRequest.ContentLength = byteArray.Length;

                using (Stream dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = webRequest.GetResponse())
                    {
                        using (StreamReader streamReader = new StreamReader(tResponse.GetResponseStream()))
                        {
                            string serverResponse = streamReader.ReadToEnd();
                            SaveNotificationLog(GoogleAppID, DeviceId, SenderId, serverResponse, "OK", 1, "SendMessageClass.SendMobMessage_IOS");

                            return new ResultSingle<string>(true) { Message = "MobileApp Notification Sent Successfully.", Data = serverResponse };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string serverResponse = ex.Message.ToString();
                string InnerException = "";
                if (ex.InnerException != null) InnerException = ex.InnerException.ToString();
                if (InnerException != "" && InnerException.Length > 3500) InnerException = InnerException.Substring(1, 3500);

                SaveNotificationLog(GoogleAppID, DeviceId, SenderId, serverResponse, "Error", 1, InnerException);

                return new ResultSingle<string>(false) { Message = "MobileApp Notification has not been sent, Details: " + serverResponse, Data = InnerException };
            }
        }

        public async Task<ResultSingle<string>> SendMobileAppNotificationNew(string DeviceId, string msgbody, string msgSubjectTitle, string msgType)
        {
            try
            {
                return await _pushNotificationSender.SendAsync(DeviceId, msgbody, msgSubjectTitle, msgType);

                //string url = _configuration["AccsoftMobileAppBaseUrl"] + "/api/Notification/Send";

                //var notificationSendSingleModel = new NotificationSendSingleModel
                //{
                //    OrgId = 1,
                //    fcmToken = DeviceId,
                //    messageBody = msgbody,
                //    messageTitle = msgSubjectTitle,
                //    messageType = msgType
                //};

                //string json = Newtonsoft.Json.JsonConvert.SerializeObject(notificationSendSingleModel);
                //Byte[] byteArray = Encoding.UTF8.GetBytes(json);

                //WebRequest webRequest = WebRequest.Create(url);
                //webRequest.Method = "post";
                //webRequest.ContentType = "application/json";
                //webRequest.ContentLength = byteArray.Length;

                //using (Stream dataStream = webRequest.GetRequestStream())
                //{
                //    dataStream.Write(byteArray, 0, byteArray.Length);
                //    using (WebResponse webResponse = webRequest.GetResponse())
                //    {
                //        using (StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
                //        {
                //            string serverResponse = streamReader.ReadToEnd();
                //            SaveNotificationLog("", DeviceId, "", serverResponse, "OK", 1, "SendMessageClass.SendMobileAppNotificationNew");

                //            return serverResponse;
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                string serverResponse = ex.Message.ToString();
                string InnerException = "";
                if (ex.InnerException != null) InnerException = ex.InnerException.ToString();
                if (InnerException != "" && InnerException.Length > 3500) InnerException = InnerException.Substring(1, 3500);

                SaveNotificationLog("", DeviceId, "", serverResponse, "Error", 1, InnerException);

                return new ResultSingle<string>(false) { Message = "MobileApp Notification has not been sent, Details: " + serverResponse, Data = InnerException };
            }
        }

        public async Task<ResultSingle<string>> SendMobileAppNotificationMultiple(List<string> DeviceIds, string msgbody, string msgSubjectTitle, string msgType)
        {
            try
            {
                return await _pushNotificationSender.SendMultipleAsync(DeviceIds, msgbody, msgSubjectTitle, msgType);

                //string url = _configuration["AccsoftMobileAppBaseUrl"] + "/api/Notification/SendMultiple";

                //var notificationSendMultipleModel = new NotificationSendMultipleModel()
                //{
                //    OrgId = 1,
                //    fcmTokens = DeviceIds,
                //    messageBody = msgbody,
                //    messageTitle = msgSubjectTitle,
                //    messageType = msgType
                //};

                //string json = Newtonsoft.Json.JsonConvert.SerializeObject(notificationSendMultipleModel);
                //Byte[] byteArray = Encoding.UTF8.GetBytes(json);

                //WebRequest webRequest = WebRequest.Create(url);
                //webRequest.Method = "POST";
                //webRequest.ContentType = "application/json";
                //webRequest.ContentLength = byteArray.Length;

                //using (Stream dataStream = webRequest.GetRequestStream())
                //{
                //    dataStream.Write(byteArray, 0, byteArray.Length);
                //    using (WebResponse webResponse = webRequest.GetResponse())
                //    {
                //        using (StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
                //        {
                //            serverResponse = streamReader.ReadToEnd();
                //            SaveNotificationLog("", string.Join(",", DeviceIds.ToArray()), "", serverResponse, "OK", 1, "SendMessageClass.SendMobileAppNotificationMultiple");

                //            return ActionResponseModel.Success(serverResponse, 1);
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                string serverResponse = ex.Message.ToString();
                string InnerException = "";
                if (ex.InnerException != null) InnerException = ex.InnerException.ToString();
                if (InnerException != "" && InnerException.Length > 3500) InnerException = InnerException.Substring(1, 3500);

                SaveNotificationLog("", string.Join(",", DeviceIds), "", serverResponse, "Error", 1, InnerException);

                return new ResultSingle<string>(false) { Message = "MobileApp Notification has not been sent, Details: " + serverResponse, Data = InnerException };
            }
        }

        private void SaveNotificationLog(string GoogleAppID, string DeviceId, string SenderId, string Response, string ResponseType, int apptype, string InnerException)
        {
            //SqlConnection connection = null;
            //string query = "INSERT INTO [dbo].[tblNotificationResponse] ([GoogleAppID],[DeviceId],[SenderId],[Response],[ResponseType],[Apptype],[InnerException]) VALUES ('" + GoogleAppID + "','" + DeviceId + "','" + SenderId + "','" + Response + "','" + ResponseType + "'," + apptype + ",'" + InnerException + "')";
            //try
            //{
            //    string connetionString = _configuration.GetConnectionString("ConnectionString");
            //    connection = new SqlConnection(connetionString);
            //    connection.Open();

            //    SqlCommand cmd = new SqlCommand(query, connection);
            //    cmd.ExecuteNonQuery();
            //}
            //catch
            //{
            //    throw;
            //}
            //finally
            //{
            //    if (connection.State == System.Data.ConnectionState.Open)
            //        connection.Close();
            //}

        }

    }
}
