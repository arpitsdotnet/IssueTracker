using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Extensions.ExceptionHandlers;
using IssueTracker.BusinessLayer.Features.Issues;
using IssueTracker.BusinessLayer.Features.Issues.Dtos;
using IssueTracker.BusinessLayer.Features.Issues.Models;
using IssueTracker.BusinessLayer.Services.Abstracts;
using IssueTracker.BusinessLayer.Services.LogService;
using IssueTracker.BusinessLayer.Services.Messaging;

namespace IssueTracker.BusinessLayer.Controllers
{
    public sealed class GetIssuesRequest : BaseModel
    {

    }

    public class GetIssuesController : CommonController
    {
        private readonly ILogger<GetIssuesController> _logger;
        private readonly GetIssuesRepository _repository;

        public GetIssuesController() {
            _logger = new FileLogger<GetIssuesController>();
            _repository = new GetIssuesRepository();        
        }

        public async Task<ResultList<Issue>> Handle(GetIssuesRequest request)
        {
            _logger.Log("GetIssues.GetIssueRequest", request);
            return await DefaultExceptionHandler.Handle(_logger, async () =>
            {
                var result = await _repository.Handle(request);

                return result;
            });
        }        
    }
}
