using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Services.Abstracts;
using IssueTracker.BusinessLayer.Services.Messaging.Models;

namespace IssueTracker.BusinessLayer.Services.Messaging
{
    public class EmailNotifier
    {
        private readonly IEmailSender _emailSender;

        public EmailNotifier(IEmailSender emailSender = null) 
        {
            _emailSender = emailSender ?? new DefaultEmailMessageService( new DefaultEmailSettingKeyModel());
        }
        public async Task<ResultSingle<string>> OnMessageSent(string sessionUid, string subject, string message)
        {
            //Get all values from sessionUid

            EmailMessageModel emailMessageModel = new EmailMessageModel()
            {
                ToEmail = "arpit_16_10@gmail.com",
                Subject = subject,
                HtmlContentBody = message
            };

            return await _emailSender.SendAsync(emailMessageModel);
        }
    }
}
