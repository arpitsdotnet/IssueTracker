using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Contracts;
using IssueTracker.BusinessLayer.Features.Issues.Models;
using IssueTracker.BusinessLayer.Services.DbContexts;

namespace IssueTracker.BusinessLayer.Features.Issues.GetIssuesByProjectId
{
    public class GetIssuesByProjectIdRepository
    {
        public readonly IApplicationDBContext _dBContext;

        public GetIssuesByProjectIdRepository()
        {
            _dBContext = DbContextFactory.Instance;
        }

        public async Task<ResultList<Issue>> Handle(GetIssuesByProjectIdRequest request)
        {
            var result = await _dBContext.LoadDataAsync<GetIssuesByProjectIdRequest, Issue>("sps_Issue", request);

            return result;
        }
    }
}
