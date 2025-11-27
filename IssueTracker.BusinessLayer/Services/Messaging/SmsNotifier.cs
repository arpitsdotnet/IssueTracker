using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Services.Abstracts;
using IssueTracker.BusinessLayer.Services.Messaging.Models;

namespace IssueTracker.BusinessLayer.Services.Messaging
{
    public class SmsNotifier
    {
        private readonly ISMSSender _smsSender;

        public SmsNotifier(ISMSSender smsSender = null)
        {
            _smsSender = smsSender ?? new DefaultSMSMessageService(new DefaultSMSSettingKeyModel());
        }

        public async Task<ResultSingle<string>> OnMessageSent(string sessionUid, string subject, string message)
        {
            //Get all values from sessionUid
            string mobileNumber = "9871914499";

            return await _smsSender.SendAsync(mobileNumber, message, "");
        }
    }
}
