using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Extensions.ExceptionHandlers;
using IssueTracker.BusinessLayer.Features.Projects.Models;
using IssueTracker.BusinessLayer.Services.Abstracts;
using IssueTracker.BusinessLayer.Services.LogService;

namespace IssueTracker.BusinessLayer.Features.Projects.GetProjects
{
    public class GetProjectsRequest : BaseModel
    {
        public int ProjectId { get; set; } = 0;
        public int ProjectManagerId { get; set; } = 0;
    }

    public class GetProjectsController
    {
        private readonly ILogger<GetProjectsController> _logger;
        private readonly GetProjectsRepository _repository;
        public GetProjectsController()
        {
            _logger = LoggerFactory<GetProjectsController>.Instance;
            _repository = new GetProjectsRepository();
        }
        public async Task<ResultList<Project>> Handle(GetProjectsRequest request)
        {
            _logger.Log("GetProjects.GetProjectRequest", request);

            var result = await _repository.Handle(request);

            return result;
            //return await DefaultExceptionHandler.Handle(_logger, async () =>
            //{
            //    //var cacheResult = _cacheClient.Get<Project>(BuildCacheKey(request.ProjectId));
            //    //if (cacheResult.HasValue)
            //    //{
            //    //    return cacheResult;
            //    //}

            //    var result = await _repository.Handle(request);
            //    //_cacheClient.Set<Project>(BuildCacheKey(request.ProjectId), result);

            //    return result;
            //});
        }
    }
}