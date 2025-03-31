using IssueTracker.BusinessLayer.Services.Abstracts;
using IssueTracker.BusinessLayer.Services.CacheService;
using IssueTracker.BusinessLayer.Services.LogService;
using IssueTracker.DataLayer.Repositories;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.SysSubCategories.Dtos;
using IssueTracker.ModelLayer.SysSubCategories.Models;

namespace IssueTracker.BusinessLayer.Controllers
{
    public class SubCategoryController : CommonController
    {
        private readonly ILogger<SubCategoryController> _logger;
        private readonly ICacheClient _cacheClient;
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryController(
            ILogger<SubCategoryController> logger,
            ICacheClient cacheClient,
            ISubCategoryRepository subCategoryRepository)
        {
            _logger = logger;
            _cacheClient = cacheClient;
            _subCategoryRepository = subCategoryRepository;
        }
        public SubCategoryController() : this(
            new FileLogger<SubCategoryController>(),
            new CacheClient(),
            new SubCategoryRepository())
        {
        }

        public ResultList<SubCategory> GetSubCategories(GetSubCategoryRequest request)
        {
            _logger.Log("GetSubCategories.GetSubCategoryRequest", request);
            return HandleBusinessException(_logger, () =>
            {
                var result = _subCategoryRepository.GetSubCategories(request);

                return result;
            });
        }
    }
}
