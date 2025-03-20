using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.SysCategories.Dtos;
using IssueTracker.ModelLayer.SysCategories.Models;

namespace IssueTracker.DataLayer.Repositories
{
    public interface ICategoryRepository
    {
        ResultList<Category> GetCategories(GetCategoryRequest request);
    }
    public class CategoryRepository : ICategoryRepository
    {
        public readonly IApplicationDBContext _dBContext;

        public CategoryRepository()
        {
            _dBContext = SQLDataAccess.Instance;
        }

        public ResultList<Category> GetCategories(GetCategoryRequest request)
        {
            var result = _dBContext.LoadData<GetCategoryRequest, Category>("sps_Categories", request);

            return result;
        }
    }
}
