using System;
using System.Collections.Generic;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Issues.Dtos;
using IssueTracker.ModelLayer.Issues.Models;

namespace IssueTracker.DataLayer.Repositories
{
    public interface IIssueRepository
    {
        ResultList<Issue> GetIssues(GetIssueRequest request);
        ResultList<Issue> SaveIssue(AddIssueRequest request);
    }

    public class IssueRepository : IIssueRepository
    {
        public readonly IApplicationDBContext _dBContext;

        public IssueRepository()
        {
            _dBContext = SQLDataAccess.Instance;
        }

        public ResultList<Issue> GetIssues(GetIssueRequest request)
        {
            var result = _dBContext.LoadData<GetIssueRequest, Issue>("sps_Issue", request);

            return result;
        }

        public ResultList<Issue> SaveIssue(AddIssueRequest request)
        {
            var result = _dBContext.SaveData("spu_Issue", request);

            return new ResultList<Issue>(result.HasValue) { Message = result.Message, Data = new List<Issue>() { new Issue { IssueId = Convert.ToInt32(result.Data) } } };
        }
    }
}
