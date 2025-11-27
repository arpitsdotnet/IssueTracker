using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirebaseAdmin.Messaging;
using IssueTracker.BusinessLayer.Base;

namespace IssueTracker.BusinessLayer.Utilities.MessageUtility
{
    public class FirebasePushNotification : IFirebasePushNotification
    {
        public async Task<ResultSingle<string>> SendAsync(string fcmToken, string messageBody, string messageTitle, string messageType)
        {
            try
            {
                var message = new Message()
                {
                    Token = fcmToken,

                    Notification = new Notification
                    {
                        Title = messageType,
                        Body = messageBody
                    },
                };
                var response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
                return new ResultSingle<string>(true) { Message = "Push Notification Sent Successfully.", Data = response };
            }
            catch (Exception ex)
            {
                return new ResultSingle<string>(false) { Message = "Oops! Something went wrong while sending push notification.", Data = ex.Message };
            }
        }

        public async Task<ResultSingle<string>> SendMultipleAsync(List<string> fcmTokens, string messageBody, string messageTitle, string messageType)
        {
            try
            {
                var message = new MulticastMessage()
                {
                    Tokens = fcmTokens,
                    Notification = new Notification
                    {
                        Title = messageType,
                        Body = messageBody
                    },
                };

                var failedResponse = "";
                var response = await FirebaseMessaging.DefaultInstance.SendMulticastAsync(message);
                if (response.FailureCount > 0)
                {
                    var failedTokens = new List<string>();
                    for (var i = 0; i < response.Responses.Count; i++)
                    {
                        if (!response.Responses[i].IsSuccess)
                        {
                            // The order of responses corresponds to the order of the registration tokens.
                            failedTokens.Add(fcmTokens[i]);
                        }
                    }
                    Console.WriteLine($"List of tokens that caused failures: {failedTokens}");
                    failedResponse = string.Format("List of {0} tokens that caused failure : {1}", response.FailureCount, string.Join(", ", failedTokens));
                }
                return new ResultSingle<string>(true) { Message = "Push Notification Sent Successfully.", Data = failedResponse };
            }
            catch (Exception ex)
            {
                return new ResultSingle<string>(false) { Message = "Oops! Something went wrong while sending push notification.", Data = ex.Message };
            }
        }        
    }
}
