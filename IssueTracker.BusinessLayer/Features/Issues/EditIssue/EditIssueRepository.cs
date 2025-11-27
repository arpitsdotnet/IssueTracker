using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Contracts;
using IssueTracker.BusinessLayer.Features.Issues.Models;
using IssueTracker.BusinessLayer.Services.DbContexts;

namespace IssueTracker.BusinessLayer.Features.Issues.EditIssue
{
    public class EditIssueRepository
    {
        public readonly IApplicationDBContext _dBContext;

        public EditIssueRepository()
        {
            _dBContext = DbContextFactory.Instance;
        }


        public async Task<ResultList<Issue>> Handle(EditIssueRequest request)
        {
            var result = await _dBContext.SaveDataAsync("spu_Issue", request);

            return new ResultList<Issue>(result.HasValue) { Message = result.Message, Data = new List<Issue>() { new Issue { IssueId = Convert.ToInt32(result.Data) } } };
        }
    }
}
