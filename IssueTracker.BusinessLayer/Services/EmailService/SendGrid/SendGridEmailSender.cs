using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Services.Messaging;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Messaging;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace AccsoftApp.Plugins.Email.SendGrid
{
    //BRIDGE PATTERN
    public interface ISendGridEmailSender : IEmailSender
    {
    }

    public class SendGridEmailSender : ISendGridEmailSender
    {
        private readonly SendGridEmailKeyModel _emailConstants;

        public SendGridEmailSender(SendGridEmailKeyModel config)
        {
            _emailConstants = config;
        }

        public async Task<ResultSingle<string>> SendAsync(EmailMessageModel model)
        {
            try
            {
                if (_emailConstants.EnabledYN == "N")
                    return null;

                SendGridMessage message = new SendGridMessage()
                {
                    From = new EmailAddress(_emailConstants.FromEmail, _emailConstants.FromName),
                    Subject = model.Subject,
                    PlainTextContent = model.PlainContentBody,
                    HtmlContent = model.HtmlContentBody
                };

                if (model.ToEmail.Contains(","))
                {
                    var emails = model.ToEmail.Split(',');

                    var toList = new List<EmailAddress>();
                    foreach (var i in emails)
                    {
                        if (string.IsNullOrEmpty(i))
                            continue;
                        toList.Add(new EmailAddress(i));
                    }

                    message = MailHelper.CreateSingleEmailToMultipleRecipients(message.From, toList, message.Subject, message.PlainTextContent, message.HtmlContent);
                }
                else
                {
                    EmailAddress to = new EmailAddress(model.ToEmail, "");
                    message = MailHelper.CreateSingleEmail(message.From, to, message.Subject, message.PlainTextContent, message.HtmlContent);
                }

                if (model.AttachmentFileByteArray != null && model.AttachmentFileByteArray.Length != 0)
                {
                    var bytes = model.AttachmentFileByteArray;
                    var file = Convert.ToBase64String(bytes);
                    message.AddAttachment(model.AttachmentFileName, file);
                }

                var client = new SendGridClient(_emailConstants.ApiKey);
                var response = await client.SendEmailAsync(message);
                if (response.IsSuccessStatusCode == false)
                {
                    return new ResultSingle<string>(false) { Message = $"Email has not been sent via SendGrid, Body: { response.Body.ToString() }, Code: { response.StatusCode.ToString() }" };
                }

                return new ResultSingle<string>(true) { Message = $"Email has been sent successfully to SendGrid, Body: { response.Body.ToString() }, Code: { response.StatusCode.ToString() }" };
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
