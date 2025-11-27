using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Contracts;
using IssueTracker.BusinessLayer.Services.DbContexts;

namespace IssueTracker.BusinessLayer.Features.SysCategories.GetSubCategoriesByCategoryCode
{
    public class GetSysSubCategoriesByCategoryCodeRepository
    {
        public readonly IApplicationDBContext _dBContext;

        public GetSysSubCategoriesByCategoryCodeRepository()
        {
            _dBContext = DbContextFactory.Instance;
        }

        public async Task<ResultList<GetSysSubCategoriesByCategoryCodeResponse>> Handle(GetSysSubCategoriesByCategoryCodeRequest request)
        {
            var result = await _dBContext.LoadDataAsync<GetSysSubCategoriesByCategoryCodeRequest, GetSysSubCategoriesByCategoryCodeResponse>("sps_GetSubCategoriesByCategoryCode", request);

            return result;
        }
    }
}
