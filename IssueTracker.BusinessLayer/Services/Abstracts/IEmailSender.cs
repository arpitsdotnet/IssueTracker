using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Services.Messaging.Models;

namespace IssueTracker.BusinessLayer.Services.Abstracts
{
    public interface IEmailSender
    {
        Task<ResultSingle<string>> SendAsync(EmailMessageModel model);
    }
}
