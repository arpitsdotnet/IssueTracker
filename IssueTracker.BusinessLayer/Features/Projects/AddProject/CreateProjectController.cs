using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Controllers;
using IssueTracker.BusinessLayer.Extensions.ExceptionHandlers;
using IssueTracker.BusinessLayer.Features.Projects.Models;
using IssueTracker.BusinessLayer.Services.Abstracts;
using IssueTracker.BusinessLayer.Services.LogService;
using IssueTracker.BusinessLayer.Services.Messaging;

namespace IssueTracker.BusinessLayer.Features.Projects.CreateProject
{
    public class CreateProjectRequest : BaseModel
    {
        public string ProjKey { get; set; }
        public string ProjTitle { get; set; }
        public string ProjIconUrl { get; set; }
        public short ProjCategoryId { get; set; }
        public short ProjTemplateId { get; set; }
        public short ProjTypeId { get; set; }
        public int ProjManagerId { get; set; }
        public int ProjDefaultAssigneeId { get; set; }
        public char ProjStatus { get; set; }
    }

    public class CreateProjectController
    {
        private readonly ILogger<CreateProjectController> _logger;
        private readonly CreateProjectRepository _repository;

        public CreateProjectController()
        {
            _logger = LoggerFactory<CreateProjectController>.Instance;
            _repository = new CreateProjectRepository();
        }


        public async Task<ResultList<Project>> Handle(CreateProjectRequest request)
        {
            _logger.Log("CreateProject.AddProjectRequest", request);
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
                    var smsNotifier = new SmsNotifier();

                    // Subscribe to the event
                    messageService.MessageSent += emailNotifier.OnMessageSent;
                    messageService.MessageSent += smsNotifier.OnMessageSent;

                    await messageService.SendMessage(
                        sessionUId,
                        $"Congratulation! Your project { request.ProjTitle } has been created.",
                        $"Dear User! Your project { request.ProjTitle } has been created."
                    );

                }

                //Form_Clear();

                return result;
            });
        }
    }
}
