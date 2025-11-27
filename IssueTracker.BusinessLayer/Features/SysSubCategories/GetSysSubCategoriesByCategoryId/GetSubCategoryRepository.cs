using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Contracts;
using IssueTracker.BusinessLayer.Features.SysCategories.GetSubCategoriesByCategoryId;
using IssueTracker.BusinessLayer.Features.SysCategories.Models;
using IssueTracker.BusinessLayer.Services.DbContexts;

namespace IssueTracker.DataLayer.Repositories
{
    public class GetSubCategoryRepository
    {
        public readonly IApplicationDBContext _dBContext;

        public GetSubCategoryRepository()
        {
            _dBContext = DbContextFactory.Instance;
        }

        public async Task<ResultList<SubCategory>> GetSubCategoriesByCategoryId(GetSubCategoriesByCategoryIdRequest request)
        {
            var result = await _dBContext.LoadDataAsync<GetSubCategoriesByCategoryIdRequest, SubCategory>("sps_SubCategories", request);

            return result;
        }
    }
}
