using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Contracts;
using IssueTracker.BusinessLayer.Services.DbContexts;

namespace IssueTracker.BusinessLayer.Features.SysCategories.GetSysCategories
{
    public class GetSysCategoriesRepository
    {
        public readonly IApplicationDBContext _dBContext;

        public GetSysCategoriesRepository()
        {
            _dBContext = DbContextFactory.Instance;
        }

        public async Task<ResultList<GetSysCategoriesResponse>> Handle(GetSysCategoriesRequest request)
        {
            var result = await _dBContext.LoadDataAsync<GetSysCategoriesRequest, GetSysCategoriesResponse>("sps_Categories", request);

            return result;
        }
    }
}
