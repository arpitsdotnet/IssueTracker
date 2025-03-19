using System;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Messaging;

namespace IssueTracker.BusinessLayer.Services.Messaging
{
    public class DefaultEmailMessageService : IEmailSender
    {
        private readonly DefaultEmailSettingKeyModel _defaultEmailMessageKeyModel;

        public DefaultEmailMessageService(DefaultEmailSettingKeyModel defaultEmailMessageKeyModel)
        {
            _defaultEmailMessageKeyModel = defaultEmailMessageKeyModel;
        }

        public async Task<ResultSingle<string>> SendAsync(EmailMessageModel emailMessageModel)
        {
            string networkEmailHost = _defaultEmailMessageKeyModel.Host;
            int networkEmailPort = _defaultEmailMessageKeyModel.Port;
            string displayName = _defaultEmailMessageKeyModel.DisplayName;
            string networkEmailId = _defaultEmailMessageKeyModel.UserId;
            string networkPassword = _defaultEmailMessageKeyModel.Password;

            var mail = new MailMessage();
            try
            {
                if (emailMessageModel.ToEmail.Length == 0)
                    return new ResultSingle<string>(false) { Message = "Email ID has not been found." };

                mail.To.Add(new MailAddress(emailMessageModel.ToEmail, emailMessageModel.ToName));

                if (emailMessageModel.CcEmail.Length > 0)
                {
                    mail.CC.Add(new MailAddress(emailMessageModel.CcEmail, emailMessageModel.CcName));
                }
                if (emailMessageModel.BccEmail.Length > 0)
                {
                    mail.Bcc.Add(new MailAddress(emailMessageModel.BccEmail, emailMessageModel.BccName));
                }

                mail.From = new MailAddress(networkEmailId, displayName);
                mail.Subject = emailMessageModel.Subject;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Body = emailMessageModel.HtmlContentBody;

                mail.Priority = MailPriority.High;
                //if (emailMessageModel.AttachmentFileByteArray != null)
                //    mail.Attachments.Add(new Attachment(emailMessageModel.AttachmentFileByteArray, emailMessageModel.AttachmentFileName);

                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(networkEmailId, networkPassword);
                client.Port = networkEmailPort;
                client.Host = networkEmailHost;
                client.EnableSsl = true;
                try
                {
                    await client.SendMailAsync(mail);
                }
                catch (System.Threading.ThreadAbortException) { } //DO NOTHING
                catch (Exception ex)
                {
                    //Log4Acc.LogError(ex, MethodBase.GetCurrentMethod());
                    return new ResultSingle<string>(false) { Message = ex.Message };
                }
            }
            catch (System.Threading.ThreadAbortException) { } //DO NOTHING
            catch (Exception ex)
            {
                //Log4Acc.LogError(ex, MethodBase.GetCurrentMethod());
                return new ResultSingle<string>(false) { Message = ex.Message };
            }
            return new ResultSingle<string>(true) { Message = "Email message sent successfully." };
        }
    }
}
