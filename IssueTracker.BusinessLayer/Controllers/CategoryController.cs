using IssueTracker.BusinessLayer.Services.Abstracts;
using IssueTracker.BusinessLayer.Services.CacheService;
using IssueTracker.BusinessLayer.Services.LogService;
using IssueTracker.DataLayer.Repositories;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.SysCategories.Dtos;
using IssueTracker.ModelLayer.SysCategories.Models;

namespace IssueTracker.BusinessLayer.Controllers
{
    public class CategoryController : CommonController
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICacheClient _cacheClient;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(
            ILogger<CategoryController> logger,
            ICacheClient cacheClient,
            ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _cacheClient = cacheClient;
            _categoryRepository = categoryRepository;
        }
        public CategoryController() : this(
            new FileLogger<CategoryController>(),
            new CacheClient(),
            new CategoryRepository())
        {
        }

        public ResultList<Category> GetCategories(GetCategoryRequest request)
        {
            _logger.Log("GetCategories.GetCategoryRequest", request);
            return HandleBusinessException(_logger, () =>
            {
                var result = _categoryRepository.GetCategories(request);

                return result;
            });
        }
    }
}
