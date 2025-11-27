using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Contracts;
using IssueTracker.BusinessLayer.Services.DbContexts;

namespace IssueTracker.BusinessLayer.Features.SysSubCategories.GetSysSubCategories
{
    public class GetSysSubCategoriesRepository
    {
        public readonly IApplicationDBContext _dBContext;

        public GetSysSubCategoriesRepository()
        {
            _dBContext = DbContextFactory.Instance;
        }

        public async Task<ResultList<GetSysSubCategoriesResponse>> Handle(GetSysSubCategoriesRequest request)
        {
            var result = await _dBContext.LoadDataAsync<GetSysSubCategoriesRequest, GetSysSubCategoriesResponse>("sps_GetSubCategories", request);

            return result;
        }
    }
}
