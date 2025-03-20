using IssueTracker.DataLayer.Repositories;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.SysSubCategories.Dtos;
using IssueTracker.ModelLayer.SysSubCategories.Models;

namespace IssueTracker.BusinessLayer.Controllers
{
    public class SubCategoryController : CommonController
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryController(ISubCategoryRepository subCategoryRepository = null)
        {
            _subCategoryRepository = subCategoryRepository ?? new SubCategoryRepository();
        }

        public ResultList<SubCategory> GetSubCategories(GetSubCategoryRequest request)
        {
            var result = _subCategoryRepository.GetSubCategories(request);

            return result;
        }
    }
}
