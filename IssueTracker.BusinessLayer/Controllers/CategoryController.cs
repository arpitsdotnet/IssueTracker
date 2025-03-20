using IssueTracker.DataLayer.Repositories;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.SysCategories.Dtos;
using IssueTracker.ModelLayer.SysCategories.Models;

namespace IssueTracker.BusinessLayer.Controllers
{
    public class CategoryController : CommonController
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository = null)
        {
            _categoryRepository = categoryRepository ?? new CategoryRepository();
        }

        public ResultList<Category> GetCategories(GetCategoryRequest request)
        {
            var result = _categoryRepository.GetCategories(request);

            return result;
        }
    }
}
