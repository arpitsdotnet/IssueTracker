using IssueTracker.BusinessLayer.Services.Abstracts;
using IssueTracker.BusinessLayer.Services.CacheService;
using IssueTracker.BusinessLayer.Services.LogService;
using IssueTracker.BusinessLayer.Services.Messaging;
using IssueTracker.DataLayer.Repositories;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Issues.Dtos;
using IssueTracker.ModelLayer.Issues.Models;

namespace IssueTracker.BusinessLayer.Controllers
{
    public class IssueController : CommonController
    {
        private readonly ILogger<IssueController> _logger;
        private readonly ICacheClient _cacheClient;
        private readonly IIssueRepository _issueRepository;

        public IssueController(
            ILogger<IssueController> logger,
            ICacheClient cacheClient,
            IIssueRepository issueRepository)
        {
            _logger = logger;
            _cacheClient = cacheClient;
            _issueRepository = issueRepository;
        }
        public IssueController() : this(
            new FileLogger<IssueController>(),
            new CacheClient(),
            new IssueRepository())
        {
        }

        public ResultList<Issue> GetIssues(GetIssueRequest request)
        {
            _logger.Log("GetIssues.GetIssueRequest", request);
            return HandleBusinessException(_logger, () =>
            {
                var result = _issueRepository.GetIssues(request);

                return result;
            });
        }

        public ResultList<Issue> CreateIssue(AddIssueRequest request)
        {
            _logger.Log("CreateIssue.AddIssueRequest", request);
            return HandleBusinessException(_logger, () =>
            {
                var result = _issueRepository.SaveIssue(request);

                if (result.HasValue == true)
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
            });
        }
    }
}
