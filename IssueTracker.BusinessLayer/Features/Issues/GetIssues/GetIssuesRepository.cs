using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Contracts;
using IssueTracker.BusinessLayer.Controllers;
using IssueTracker.BusinessLayer.Features.Issues.Models;
using IssueTracker.BusinessLayer.Services.DbContexts;

namespace IssueTracker.BusinessLayer.Features.Issues
{
    public class GetIssuesRepository
    {
        public readonly IApplicationDBContext _dBContext;

        public GetIssuesRepository()
        {
            _dBContext = DbContextFactory.Instance;
        }

        public async Task<ResultList<Issue>> Handle(GetIssuesRequest request)
        {
            var result = await _dBContext.LoadDataAsync<GetIssuesRequest, Issue>("sps_Issue", request);

            return result;
        }

    }
}
