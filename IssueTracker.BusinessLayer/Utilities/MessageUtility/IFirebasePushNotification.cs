using System.Collections.Generic;
using System.Threading.Tasks;
using IssueTracker.ModelLayer.Base;

namespace IssueTracker.BusinessLayer.Utilities.MessageUtility
{
    public interface IFirebasePushNotification
    {
        Task<ResultSingle<string>> SendAsync(string fcmToken, string messageBody, string messageTitle, string messageType);

        Task<ResultSingle<string>> SendMultipleAsync(List<string> fcmTokens, string messageBody, string messageTitle, string messageType);
    }
}