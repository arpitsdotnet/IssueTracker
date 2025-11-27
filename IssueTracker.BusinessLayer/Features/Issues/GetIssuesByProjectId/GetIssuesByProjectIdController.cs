using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Controllers;
using IssueTracker.BusinessLayer.Features.Issues.Models;
using IssueTracker.BusinessLayer.Services.Abstracts;
using IssueTracker.BusinessLayer.Services.LogService;

namespace IssueTracker.BusinessLayer.Features.Issues.GetIssuesByProjectId
{
    public sealed class GetIssuesByProjectIdRequest : BaseModel
    {
        public int ProjectId { get; set; }
    }

    public class GetIssuesByProjectIdController : CommonController
    {
        private readonly ILogger<GetIssuesByProjectIdController> _logger;
        private readonly GetIssuesByProjectIdRepository _repository;

        public GetIssuesByProjectIdController()
        {
            _logger = new FileLogger<GetIssuesByProjectIdController>();
            _repository = new GetIssuesByProjectIdRepository();

        }

        public async Task<ResultList<Issue>> Handle(GetIssuesByProjectIdRequest request)
        {
            _logger.Log("GetIssues.GetIssueRequest", request);

            if (request.ProjectId == 0)
                return new ResultList<Issue>(false) { Message = "Project Id should not be 0." };

            var result = await _repository.Handle(request);

            return result;
            //return await DefaultExceptionHandler.Handle(_logger, async () =>
            //{
            //});
        }
    }
}
