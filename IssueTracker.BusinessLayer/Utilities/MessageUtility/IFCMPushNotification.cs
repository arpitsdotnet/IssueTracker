using System.Threading.Tasks;
using IssueTracker.ModelLayer.Base;

namespace IssueTracker.BusinessLayer.Utilities.MessageUtility
{
    public interface IFCMPushNotification
    {
        Task<ResultSingle<string>> SendAsyncActual(string fcmToken, string messageBody, string messageTitle, string messageType);
    }
}