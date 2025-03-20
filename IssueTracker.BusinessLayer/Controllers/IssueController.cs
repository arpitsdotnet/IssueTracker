using IssueTracker.BusinessLayer.Services.Messaging;
using IssueTracker.DataLayer.Repositories;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Issues.Dtos;
using IssueTracker.ModelLayer.Issues.Models;

namespace IssueTracker.BusinessLayer.Controllers
{
    public class IssueController : CommonController
    {
        private readonly IIssueRepository _issueRepository;

        public IssueController(IIssueRepository issueRepository = null)
        {
            _issueRepository = issueRepository ?? new IssueRepository();
        }

        public ResultList<Issue> GetIssues(GetIssueRequest request)
        {
            var result = _issueRepository.GetIssues(request);

            return result;
        }

        public ResultSingle<Issue> CreateIssue(AddIssueRequest request)
        {
            var result = _issueRepository.SaveIssue(request);

            if (result.IsSuccess == true)
            {
                var sessionUId = request.SessionUId;

                // Create the message service
                var messageService = new MessageService();

                // Create listeners
                var emailNotifier = new EmailNotifier();

                // Subscribe to the event
                messageService.MessageSent += emailNotifier.OnMessageSent;

                messageService.SendMessage(
                    sessionUId,
                    $"Congratulation! Your issue { request.IssueTitle } has been created.",
                    $"Dear User! Your issue { request.IssueTitle } has been created."
                ).GetAwaiter().GetResult();

            }

            return result;
        }
    }
}
