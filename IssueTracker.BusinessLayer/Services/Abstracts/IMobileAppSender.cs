using System.Collections.Generic;
using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;

namespace IssueTracker.BusinessLayer.Services.Abstracts
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
}
