using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;

namespace IssueTracker.BusinessLayer.Services.Abstracts
{
    public interface ISMSSender
    {
        Task<ResultSingle<string>> SendAsync(string mobileNumber, string messageBody, string templateId);
    }
}
