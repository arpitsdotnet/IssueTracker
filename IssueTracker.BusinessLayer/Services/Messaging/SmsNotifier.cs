using System.Threading.Tasks;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Messaging;

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
