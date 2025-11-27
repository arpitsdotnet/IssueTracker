using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Controllers;
using IssueTracker.BusinessLayer.Extensions.ExceptionHandlers;
using IssueTracker.BusinessLayer.Features.Issues.Dtos;
using IssueTracker.BusinessLayer.Features.Issues.Models;
using IssueTracker.BusinessLayer.Services.Abstracts;
using IssueTracker.BusinessLayer.Services.LogService;
using IssueTracker.BusinessLayer.Services.Messaging;

namespace IssueTracker.BusinessLayer.Features.Issues.CreateIssue
{
    public sealed class CreateIssueRequest : BaseModel
    {
        public int ProjectId { get; set; }
        public int IssueTypeId { get; set; }
        public string IssueTitle { get; set; }
    }

    public class CreateIssueController : CommonController
    {
        private readonly ILogger<CreateIssueController> _logger;
        private readonly CreateIssueRepository _repository;

        public CreateIssueController()
        {
            _logger = new FileLogger<CreateIssueController>();
            _repository = new CreateIssueRepository();

        }


        public async Task<ResultList<Issue>> Handle(CreateIssueRequest request)
        {
            _logger.Log("CreateIssue.AddIssueRequest", request);
            return await DefaultExceptionHandler.Handle(_logger, async () =>
            {
                var result = await _repository.Handle(request);

                if (result.HasValue == true)
                {
                    var sessionUId = request.SessionUID;

                    // Create the message service
                    var messageService = new MessageService();

                    // Create listeners
                    var emailNotifier = new EmailNotifier();

                    // Subscribe to the event
                    messageService.MessageSent += emailNotifier.OnMessageSent;

                    await messageService.SendMessage(
                        sessionUId,
                        $"Congratulation! Your issue { request.IssueTitle } has been created.",
                        $"Dear User! Your issue { request.IssueTitle } has been created."
                    );

                }

                return result;
            });
        }
    }
}
