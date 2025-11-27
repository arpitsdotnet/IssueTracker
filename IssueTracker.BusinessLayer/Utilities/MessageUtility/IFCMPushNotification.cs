using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;

namespace IssueTracker.BusinessLayer.Utilities.MessageUtility
{
    public interface IFCMPushNotification
    {
        Task<ResultSingle<string>> SendAsyncActual(string fcmToken, string messageBody, string messageTitle, string messageType);
    }
}