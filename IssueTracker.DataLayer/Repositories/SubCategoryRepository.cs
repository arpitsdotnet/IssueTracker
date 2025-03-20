using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.SysSubCategories.Dtos;
using IssueTracker.ModelLayer.SysSubCategories.Models;

namespace IssueTracker.DataLayer.Repositories
{
    public interface ISubCategoryRepository
    {
        ResultList<SubCategory> GetSubCategories(GetSubCategoryRequest request);
    }
    public class SubCategoryRepository : ISubCategoryRepository
    {
        public readonly IApplicationDBContext _dBContext;

        public SubCategoryRepository()
        {
            _dBContext = SQLDataAccess.Instance;
        }

        public ResultList<SubCategory> GetSubCategories(GetSubCategoryRequest request)
        {
            var result = _dBContext.LoadData<GetSubCategoryRequest, SubCategory>("sps_SubCategories", request);

            return result;
        }
    }
}
