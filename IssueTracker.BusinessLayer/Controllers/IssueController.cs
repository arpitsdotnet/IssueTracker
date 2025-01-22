using System;
using IssueTracker.DataLayer;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.Issues.Objects;
using IssueTracker.ModelLayer.Issues.Requests;

namespace IssueTracker.BusinessLayer.Controllers
{
    public class IssueController : CommonController
    {
        private readonly IApplicationDBContext _dBContext;
        public IssueController()
        {
            _dBContext = SQLDataAccess.Instance;
        }

        public ResultList<Issue> GetIssues(GetIssueRequest issueRequest)
        {
            var data = _dBContext.LoadData<GetIssueRequest, Issue>("sps_Issue", issueRequest);

            return data;
        }

        public ResultSingle<Issue> AddIssue(AddIssueRequest issueRequest)
        {
            var data = _dBContext.SaveData<int>("spu_Issue", issueRequest);

            return new ResultSingle<Issue>(data.IsSuccess) { Message = data.Message, Data = new Issue { IssueId = data.Data } };
        }
    }
}
